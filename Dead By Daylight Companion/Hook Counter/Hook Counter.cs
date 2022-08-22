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
        public Hook_Counter() {
            Disposed += Hook_Counter_Disposed;
            InitializeComponent();
        }

        private void Hook_Counter_Disposed(object sender, EventArgs e) {
            Frame.Dispose();
            Hook.Dispose();
            Stage2.Dispose();
            EndGame.Dispose();
        }

        static overlay ov = new overlay();
        public static bool bInitOverlay = false;
        public static string res = Screen.PrimaryScreen.Bounds.Width.ToString() + Screen.PrimaryScreen.Bounds.Height.ToString(),
                             CurFontName = Properties.Settings.Default.FontName,
                             HookText;
        public static int CurFontSize = Properties.Settings.Default.FontSize;
        public static List<string> hCount = new List<string>();
        public static List<string> _2stage = new List<string>();
        private Mat Frame;
        private Mat Hook, Stage2, EndGame;

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

        private bool CompareToTemplate(Mat source, Mat template, double threshold, out OpenCvSharp.Point maxLoc) {
            using (var result = new Mat(source.Rows - template.Rows + 1, source.Cols - template.Cols + 1, MatType.CV_32FC1)) {
                Cv2.MatchTemplate(source, template, result, TemplateMatchModes.CCoeffNormed);
                Cv2.Threshold(result, result, threshold, 1.0, ThresholdTypes.Tozero);
                Cv2.MinMaxLoc(result, out _, out double maxVal, out _, out maxLoc);
                return maxVal >= threshold;
            }
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
            ReloadRes();
        }

        private void IGUIScale_SelectedIndexChanged(object sender, EventArgs e) {
            Properties.Settings.Default.IGUIScale = IGUIScale.SelectedIndex;
            Properties.Settings.Default.Save();
            ReloadRes();
        }

        private void HookTextBox_TextChanged(object sender, EventArgs e) {
            HookText = HookTextBox.Text;
            Properties.Settings.Default.HookedText = HookText;
        }

        private void ReloadRes() {
            if (!string.IsNullOrEmpty(IGUIScale.Text)) {
                using (var h = new Mat($@"resources\{res}\hook{IGUIScale.Text}.png"))
                    Hook = h.CvtColor(ColorConversionCodes.BGR2GRAY);

                using (var s2 = new Mat($@"resources\{res}\2stage{IGUIScale.Text}.png"))
                    Stage2 = s2.CvtColor(ColorConversionCodes.BGR2GRAY);
            }

            if (!string.IsNullOrEmpty(UIScale.Text)) {
                using (var eg = new Mat($@"resources\{res}\endgame{UIScale.Text}.png"))
                    EndGame = eg.CvtColor(ColorConversionCodes.BGR2GRAY);
            }
        }

        private void CountStageCB_CheckedChanged(object sender, EventArgs e) {
            if (CountStageCB.Checked) {
                if (!File.Exists($@"resources\{res}\2stage100.png")) {
                    CountStageCB.Checked = false;
                    MessageBox.Show("Second Stage Resources Not Found, Disabling");
                }
                else {
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

            // Grab the screen.
            // TODO: Grab just DBD, not the whole screen.
            Frame?.Dispose();
            using (var b = new Bitmap(Screen.PrimaryScreen.Bounds.Width / 5, Screen.PrimaryScreen.Bounds.Height))
            using (var g = Graphics.FromImage(b)) {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X / 5,
                        Screen.PrimaryScreen.Bounds.Y,
                        0,
                        0,
                        Screen.PrimaryScreen.Bounds.Size,
                        CopyPixelOperation.SourceCopy);
                using (var m = BitmapConverter.ToMat(b)) {
                    Frame = m.CvtColor(ColorConversionCodes.BGR2GRAY);
                }
            }

            // Check for first hook.
            if (CompareToTemplate(Frame, Hook, LowerThreshCheckbox.Checked ? 0.8 : 0.9, out OpenCvSharp.Point hookLoc)) {
                hCount.Add(hookLoc.Y.ToString());
                overlay.bHasDrawn = false;
            }

            // Check for second stage.
            if (CountStageCB.Checked && CompareToTemplate(Frame, Stage2, 0.9, out OpenCvSharp.Point stage2Loc)) {
                _2stage.Add(stage2Loc.Y.ToString());
                overlay.bHasDrawn = false;
            }

            // Check for endgame.
            if (CompareToTemplate(Frame, EndGame, 0.9, out OpenCvSharp.Point _)) {
                overlay.G?.Clear(Color.Black);
                overlay.sList.Clear();
                overlay._2List.Clear();
                _2stage.Clear();
                hCount.Clear();
            }
        }
    }
}
