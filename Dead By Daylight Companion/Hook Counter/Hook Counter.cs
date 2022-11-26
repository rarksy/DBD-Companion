using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;
using OpenCvSharp.Extensions;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Dead_By_Daylight_Companion.helper;

namespace Dead_By_Daylight_Companion.Hook_Counter {
    public partial class Hook_Counter : Form {
        public Hook_Counter() {
            InitializeComponent();
            ov.Show();
        }

        readonly overlay ov = new overlay();
        public static string res = Screen.PrimaryScreen.Bounds.Width.ToString() + Screen.PrimaryScreen.Bounds.Height.ToString();

        private Mat Frame, Hook, Stage2, Endgame;

        [DllImport("User32.dll")]
        extern static void ReleaseCapture();

        [DllImport("User32.dll")]
        extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ExitHookCounter_Click(object sender, EventArgs e) {
            ClearAll();
            this.Close();
        }

        private void MinimizeHookCounter_MouseEnter(object sender, EventArgs e) {
            MinimizeHookCounter.ForeColor = Color.Red;
        }

        private void MinimizeHookCounter_MouseLeave(object sender, EventArgs e) {
            MinimizeHookCounter.ForeColor = Color.Silver;
        }

        private void MinimizeHookCounter_Click(object sender, EventArgs e) {
            for (int i = Width; i >= 0; i--) {
                Width -= 10;
                Height -= 10;
            }
            WindowState = FormWindowState.Minimized;
        }

        private void ExitHookCounter_MouseEnter(object sender, EventArgs e) {
            ExitHookCounter.ForeColor = Color.Red;
        }

        private void ExitHookCounter_MouseLeave(object sender, EventArgs e) {
            ExitHookCounter.ForeColor = Color.Silver;
        }

        private void Hook_Counter_Activated(object sender, EventArgs e) {
            Width = 477;
            Height = 284;
        }

        static void Convert_To_1080p(Mat src) {
            Cv2.Resize(src, src, new OpenCvSharp.Size(src.Width / 1.3, src.Height / 1.3));
        }
        private static bool Find_Element(Mat source, Mat template, double threshold, out OpenCvSharp.Point maxLoc, out double maxVal) {
            using (var result = new Mat(source.Rows - template.Rows + 1, source.Cols - template.Cols + 1, MatType.CV_32FC1)) {
                Cv2.MatchTemplate(source, template, result, TemplateMatchModes.CCoeffNormed);
                Cv2.Threshold(result, result, threshold, 1.0, ThresholdTypes.Tozero);
                Cv2.MinMaxLoc(result, out _, out maxVal, out _, out maxLoc);
                return maxVal >= threshold;

            }
        }

        private void TitlePanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void TitleLabel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            TitlePanel_MouseDown(sender, e);
        }

        private void UIScale_SelectedIndexChanged(object sender, EventArgs e) {
            Properties.Settings.Default.UIScale = UIScale.SelectedIndex;
            Properties.Settings.Default.Save();
            ReloadRes();
        }

        private void IGUIScale_SelectedIndexChanged(object sender, EventArgs e) {
            Properties.Settings.Default.IGUIScale = IGUIScale.SelectedIndex;
            Properties.Settings.Default.Save();
            ReloadRes();
        }
        int ks1 = Properties.Settings.Default.BIND_S1, 
            ks2 = Properties.Settings.Default.BIND_S2, 
            ks3 = Properties.Settings.Default.BIND_S3, 
            ks4 = Properties.Settings.Default.BIND_S4;
        private void BIND_S1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
            kb.Register_Bind(e, ref ks1, ref BIND_S1);
            Properties.Settings.Default.BIND_S1 = ks1;
            Properties.Settings.Default.Save();
            this.ActiveControl = null;
        }

        private void BIND_S2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
            kb.Register_Bind(e, ref ks2, ref BIND_S2);
            Properties.Settings.Default.BIND_S2 = ks2;
            Properties.Settings.Default.Save();
            this.ActiveControl = null;
        }

        private void BIND_S3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
            kb.Register_Bind(e, ref ks3, ref BIND_S3);
            Properties.Settings.Default.BIND_S3 = ks3;
            Properties.Settings.Default.Save();
            this.ActiveControl = null;
        }

        private void BIND_S4_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
            kb.Register_Bind(e, ref ks4, ref BIND_S4);
            Properties.Settings.Default.BIND_S4 = ks4;
            Properties.Settings.Default.Save();
            this.ActiveControl = null;
        }


        int[] temp;
        int[] temp_second;
        public static bool bUpdated, bClear;
        private static void update_survivor(ref int i, int j ) {

            //need to create logic to update and render the next hook

            overlay.bHasDrawn = false;
        }
        private void KeypressTimer_Tick(object sender, EventArgs e) {
            temp = survs.OrderByDescending(x => x).ToArray();
            temp_second = survs_secondstage.OrderByDescending(x => x).ToArray();
            if (ActiveForm == null) {
                
                byte[] rKS1 = BitConverter.GetBytes(GetAsyncKeyState(ks1));
                byte[] rKS2 = BitConverter.GetBytes(GetAsyncKeyState(ks2));
                byte[] rKS3 = BitConverter.GetBytes(GetAsyncKeyState(ks3));
                byte[] rKS4 = BitConverter.GetBytes(GetAsyncKeyState(ks4));

                if (rKS1[0] == 1) {
                    update_survivor(ref overlay.s1, temp[0]);
                    Console.WriteLine("s1");   
                }
                if (rKS2[0] == 1) {
                    update_survivor(ref overlay.s2, temp[1]);
                    Console.WriteLine("s2");
                }
                if (rKS3[0] == 1) {
                    update_survivor(ref overlay.s3, temp[2]);
                    Console.WriteLine("s3");
                }
                if (rKS4[0] == 1) {
                    update_survivor(ref overlay.s4, temp[3]);
                    Console.WriteLine("s4");
                }
            }

        }

        private void PlaySoundOnRenderCB_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.bPlaySound = PlaySoundOnRenderCB.Checked;
            Properties.Settings.Default.Save();

            vol_label.Visible = PlaySoundOnRenderCB.Checked;
            sound_VolumeTB.Visible = PlaySoundOnRenderCB.Checked;
            SoundTextBox.Visible = PlaySoundOnRenderCB.Checked;
            ChangeSoundButton.Visible = PlaySoundOnRenderCB.Checked;
        }

        private void ChangeSoundButton_Click(object sender, EventArgs e) {

            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "Audio Files|*.wav;*.mp3";

                if (ofd.ShowDialog() == DialogResult.OK) {
                    SoundTextBox.Text = ofd.SafeFileName;
                    Properties.Settings.Default.sSoundLocation = ofd.FileName;
                    Properties.Settings.Default.sSoundName = ofd.SafeFileName;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void ReloadRes() {
            if (!string.IsNullOrEmpty(IGUIScale.Text)) {
                Hook?.Dispose();
                Hook = new Mat($@"resources\hook{IGUIScale.Text}.png", ImreadModes.Grayscale);
                Stage2?.Dispose();
                Stage2 = new Mat($@"resources\2stage{IGUIScale.Text}.png", ImreadModes.Grayscale);
                Endgame?.Dispose();
                Endgame = new Mat($@"resources\endgame{UIScale.Text}.png", ImreadModes.Grayscale);

            }

            if (Screen.PrimaryScreen.Bounds.Height == 1080) {
                Convert_To_1080p(Hook);
                Convert_To_1080p(Stage2);
                Convert_To_1080p(Endgame);
            }
        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void sound_VolumeTB_Scroll(object sender, EventArgs e) {
            Properties.Settings.Default.iSoundVolume = float.Parse(sound_VolumeTB.Value.ToString());
            Properties.Settings.Default.Save();
        }

        private void SoundTextBox_TextChanged(object sender, EventArgs e) {

        }

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private void Hook_Counter_Load(object sender, EventArgs e) {
            UIScale.SelectedIndex = Properties.Settings.Default.UIScale;
            IGUIScale.SelectedIndex = Properties.Settings.Default.IGUIScale;

            PlaySoundOnRenderCB.Checked = Properties.Settings.Default.bPlaySound;
            SoundTextBox.Text = Properties.Settings.Default.sSoundName;
            vol_label.Visible = PlaySoundOnRenderCB.Checked;
            sound_VolumeTB.Visible = PlaySoundOnRenderCB.Checked;
            SoundTextBox.Visible = PlaySoundOnRenderCB.Checked;
            ChangeSoundButton.Visible = PlaySoundOnRenderCB.Checked;
            BIND_S1.Text = KeyInterop.KeyFromVirtualKey(ks1).ToString();
            BIND_S2.Text = KeyInterop.KeyFromVirtualKey(ks2).ToString();
            BIND_S3.Text = KeyInterop.KeyFromVirtualKey(ks3).ToString();
            BIND_S4.Text = KeyInterop.KeyFromVirtualKey(ks4).ToString();

            Thread.Start();
            KeypressTimer.Start();
        }
        public static int[] survs = { 0, 0, 0, 0 };
        public static int[] survs_secondstage = { 0, 0, 0, 0 };
        OpenCvSharp.Point first_location = new OpenCvSharp.Point(), second_location = new OpenCvSharp.Point();
        private void Thread_Tick(object sender, EventArgs e) {

            Frame?.Dispose();
            Rectangle bounds = Screen.GetBounds(System.Drawing.Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width / 5, bounds.Height)) {
                using (Graphics g = Graphics.FromImage(bitmap)) {
                    g.CopyFromScreen(System.Drawing.Point.Empty, System.Drawing.Point.Empty, bounds.Size);
                }

                Frame = BitmapConverter.ToMat(bitmap);
                Mat FrameGray = Frame.CvtColor(ColorConversionCodes.BGR2GRAY);
                bool FindFirst = Find_Element(FrameGray, Hook, LowerThreshCheckbox.Checked ? 0.8 : 0.9, out first_location, out double mv);
                bool FindSecond = Find_Element(FrameGray, Stage2, 0.9, out second_location, out double mv2);
                    if (FindFirst && survs[3] == 0) { //First Hook
                        while (true) {
                            if (survs[0] == 0) {
                                survs[0] = first_location.Y;
                                overlay.bHasDrawn = false;
                                break;
                            
                            }
                            if (survs[1] == 0) {
                                if (!Enumerable.Range(survs[0] - 10, 40).Contains(first_location.Y)) {
                                    survs[1] = first_location.Y;
                                    overlay.bHasDrawn = false;
                                }
                                break;
                            
                            }
                            if (survs[2] == 0) {
                                if (!Enumerable.Range(survs[0] - 10, 40).Contains(first_location.Y)) {
                                    if (!Enumerable.Range(survs[1] - 10, 40).Contains(first_location.Y)) {
                                        survs[2] = first_location.Y;
                                        overlay.bHasDrawn = false;
                                        
                                    }
                                }
                                break;

                            }
                            if (survs[3] == 0) {
                                if (!Enumerable.Range(survs[0] - 10, 40).Contains(first_location.Y) &&
                                    !Enumerable.Range(survs[1] - 10, 40).Contains(first_location.Y) &&
                                    !Enumerable.Range(survs[2] - 10, 40).Contains(first_location.Y)) {
                                    survs[3] = first_location.Y;
                                    overlay.bHasDrawn = false;
                                    
                                }
                                break;
                            }

                            break;
                        }
                        
                        temp = survs.OrderByDescending(x => x).ToArray();

                } // First Hook

                    if (FindSecond && survs_secondstage[3] == 0) { // Second Hook
                    if (FindFirst && Enumerable.Range(first_location.Y, 60).Contains(second_location.Y))
                        while (true) {
                            if (survs_secondstage[0] == 0) {
                                survs_secondstage[0] = second_location.Y;
                                overlay.bHasDrawn = false;
                                
                                break;

                            }
                            if (survs_secondstage[1] == 0) {
                                if (!Enumerable.Range(survs_secondstage[0] - 10, 40).Contains(second_location.Y)) {
                                    survs_secondstage[1] = second_location.Y;
                                    overlay.bHasDrawn = false;
                                    
                                }
                                break;

                            }
                            if (survs_secondstage[2] == 0) {
                                if (!Enumerable.Range(survs_secondstage[0] - 10, 40).Contains(second_location.Y) &&
                                    !Enumerable.Range(survs_secondstage[1] - 10, 40).Contains(second_location.Y)) {

                                    survs_secondstage[2] = second_location.Y;
                                    overlay.bHasDrawn = false;
                                    
                                }
                                break;

                            }
                            if (survs_secondstage[3] == 0) {
                                if (!Enumerable.Range(survs_secondstage[0] - 10, 40).Contains(second_location.Y) &&
                                    !Enumerable.Range(survs_secondstage[1] - 10, 40).Contains(second_location.Y) &&
                                    !Enumerable.Range(survs_secondstage[2] - 10, 40).Contains(second_location.Y)) {
                                    survs_secondstage[3] = second_location.Y;
                                    overlay.bHasDrawn = false;
                                    
                                }
                                break;
                            }
                            break;
                        }

                    temp_second = survs_secondstage.OrderByDescending(x => x).ToArray();
                } // Second Hook
                
                    

                if (Find_Element(FrameGray, Endgame, 0.8, out _, out _)) {
                    ClearAll();
                }
                
                FrameGray.Dispose();
            }


        }
        private static void ClearAll() {
            overlay.G?.Clear(Color.Black);
            overlay.G2?.Clear(Color.Black);
        }

        private static int Average(List<int> list) {
            int sum = 0;
            foreach (int i in list)
                sum += i;
            return sum / list.Count;
        }

    }
}
