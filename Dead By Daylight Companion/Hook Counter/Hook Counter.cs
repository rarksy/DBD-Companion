using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Dead_By_Daylight_Companion.Hook_Counter {
    public partial class Hook_Counter : Form {
        public Hook_Counter() => InitializeComponent();
        static overlay ov = new overlay();
        public static bool bInitOverlay = false, bCheckEndGame = true;
        public static string res = Screen.PrimaryScreen.Bounds.Width + Screen.PrimaryScreen.Bounds.Height.ToString(),
                             CurFontName = Properties.Settings.Default.FontName,
                             HookText;
        public static int CurFontSize = Properties.Settings.Default.FontSize;
        public static List<string> hCount = new List<string>();
        public static List<string> _2stage = new List<string>();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] public extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] public extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        private void ExitHookCounter_Click(object sender, EventArgs e) {
            Environment.Exit(0);
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
            Width = 475;
            Height = 407;
        }

        private void ChangeFont_Click(object sender, EventArgs e) {
            FontDialog fd = new FontDialog();

            if (fd.ShowDialog() == DialogResult.OK) {
                CurFontName = fd.Font.Name;
                CurFontSize = (int)fd.Font.Size;
                FontLabel.Text = $"Font: {CurFontName}";
                FontSizeLabel.Text = $"Font Size: {CurFontSize}";
                Properties.Settings.Default.FontName = CurFontName;
                Properties.Settings.Default.FontSize = CurFontSize;
                Properties.Settings.Default.Save();
            }
        }
        
        private Bitmap ITM(Mat source, string template, double dthreshold, ref List<string> count) {
            using (Mat tempMat = new Mat(template))
            using (Mat newMat = new Mat(source.Rows - tempMat.Rows + 1, source.Cols - tempMat.Cols + 1, MatType.CV_32FC1)) {
                Mat sourceGRAY = source.CvtColor(ColorConversionCodes.BGR2GRAY);
                Mat tempGRAY = tempMat.CvtColor(ColorConversionCodes.BGR2GRAY);
                Cv2.MatchTemplate(sourceGRAY, tempGRAY, newMat, TemplateMatchModes.CCoeffNormed);
                sourceGRAY.Dispose();
                tempGRAY.Dispose();
                Cv2.Threshold(newMat, newMat, dthreshold, 1.0, ThresholdTypes.Tozero);

                while (true) {
                    double mnval, mxval;
                    OpenCvSharp.Point mnloc, mxloc;
                    Cv2.MinMaxLoc(newMat, out mnval, out mxval, out mnloc, out mxloc);

                    if (mxval >= dthreshold) {
                        if (template.Contains("endgame") && bCheckEndGame) {
                            if (overlay.G != null) overlay.G.Clear(Color.Black);
                            overlay.sList.Clear();
                            overlay._2List.Clear();
                            _2stage.Clear();
                            hCount.Clear();
                            break;
                        }
                        count.Add(mxloc.Y.ToString());
                        Rect r = new Rect(new OpenCvSharp.Point(mxloc.X, mxloc.Y), new OpenCvSharp.Size(tempMat.Width, tempMat.Height));
                        Rect outRect;
                        Cv2.FloodFill(newMat, mxloc, new Scalar(0), out outRect, new Scalar(0.1), new Scalar(1.0));
                        overlay.bHasDrawn = false;
                    }
                    else
                        break;
                }
                newMat.Dispose();
                tempMat.Dispose();

                return source.ToBitmap();
            }
        }
        private Bitmap GetFrame() {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width / 5, Screen.PrimaryScreen.Bounds.Height);
            using (var g = Graphics.FromImage(bmp)) {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X / 5,
                        Screen.PrimaryScreen.Bounds.Y,
                        0,
                        0,
                        Screen.PrimaryScreen.Bounds.Size,
                        CopyPixelOperation.SourceCopy);
                g.Dispose();
            }
            return bmp;
        }

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void TitleLabel_MouseDown(object sender, MouseEventArgs e) {
            TitlePanel_MouseDown(sender, e);
        }
        
        private void UIScale_SelectedIndexChanged(object sender, EventArgs e) {
            Properties.Settings.Default.UIScale = UIScale.SelectedIndex;
            Properties.Settings.Default.Save();
        }
        
        private void IGUIScale_SelectedIndexChanged(object sender, EventArgs e) {
            Properties.Settings.Default.IGUIScale = IGUIScale.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void HookTextBox_TextChanged(object sender, EventArgs e) {
            HookText = HookTextBox.Text;
            Properties.Settings.Default.HookedText = HookText;
        }

        private void CountStageCB_CheckedChanged(object sender, EventArgs e) {
            if (CountStageCB.Checked) {
                if (!File.Exists($@"resources\{res}\2stage100.png")) {
                    CountStageCB.Checked = false;
                    MessageBox.Show("Second Stage Resources Not Found, Disabling");
                } else {
                    Properties.Settings.Default.CountStages = true;
                    HookTextBox.Enabled = false;
                    HookText = "I";
                }
            }
            else {
                Properties.Settings.Default.CountStages = false;
                HookTextBox.Enabled = true;
                HookText = HookTextBox.Text;
            }
            Properties.Settings.Default.Save();
        }

            private void Hook_Counter_Load(object sender, EventArgs e) {
            UIScale.SelectedIndex = Properties.Settings.Default.UIScale; 
            IGUIScale.SelectedIndex = Properties.Settings.Default.IGUIScale;
            HookTextBox.Text = Properties.Settings.Default.HookedText;
            CountStageCB.Checked = Properties.Settings.Default.CountStages;
            FontLabel.Text = $"Font: {CurFontName}";
            FontSizeLabel.Text = $"Font Size: {CurFontSize}";
            
            Thread.Start();
        }

        private void Thread_Tick(object sender, EventArgs e) {
            if (!bInitOverlay) {
                overlay ov = new overlay();
                ov.Show();
                bInitOverlay = true;
            }
            Bitmap frame = GetFrame();
            Mat mat = BitmapConverter.ToMat(frame);
            Bitmap det_first = ITM(mat, $@"resources\{res}\hook{IGUIScale.Text}.png", LowerThreshCheckbox.Checked ? 0.8 : 0.9, ref hCount);
            if (CountStageCB.Checked) {
                Bitmap det_second = ITM(mat, $@"resources\{res}\2stage{IGUIScale.Text}.png", 0.9, ref _2stage);
                det_second.Dispose();
            }
            Bitmap det_endgame = ITM(mat, $@"resources\{res}\endgame{UIScale.Text}.png", 0.9, ref hCount);

            frame.Dispose();
            mat.Dispose();
            det_first.Dispose();
            det_endgame.Dispose();
        }
    }
}
