using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace Dead_By_Daylight_Companion.Hook_Counter {
    public partial class Hook_Counter : Form {
        public Hook_Counter() {
            Disposed += Hook_Counter_Disposed;
            InitializeComponent();
        }

        private void Hook_Counter_Disposed(object sender, EventArgs e) {
            BmScreen.Dispose();
            Frame.Dispose();
            Hook.Dispose();
            Stage2.Dispose();
            Endgame.Dispose();
        }

        static overlay ov = new overlay();
        private readonly System.Drawing.Size leftmostFifth = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width / 5, Screen.PrimaryScreen.Bounds.Height);
        public static bool bInitOverlay = false;
        public static string res = Screen.PrimaryScreen.Bounds.Width.ToString() + Screen.PrimaryScreen.Bounds.Height.ToString(),
                             CurFontName = Properties.Settings.Default.FontName,
                             HookText;
        public static int CurFontSize = Properties.Settings.Default.FontSize;
        public static List<int> hCount = new List<int>();
        public static List<int> _2stage = new List<int>();
        private readonly Bitmap BmScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width / 5, Screen.PrimaryScreen.Bounds.Height);
        private readonly Mat Frame = new Mat(new OpenCvSharp.Size(Screen.PrimaryScreen.Bounds.Size.Width / 5, Screen.PrimaryScreen.Bounds.Size.Height), MatType.CV_8UC3);
        private Mat Hook, Stage2, Endgame, HookResult, Stage2Result, EndgameResult;

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

        private bool MatchesTemplate(Mat source, Mat template, Mat result, double threshold) {
            Cv2.MatchTemplate(source, template, result, TemplateMatchModes.CCoeffNormed);
            Cv2.MinMaxLoc(result, out _, out double maxVal);
            return maxVal >= threshold;
        }

        private bool FindMatch(Mat source, Mat template, double threshold, out OpenCvSharp.Point maxLoc) {
            using (var result = new Mat(source.Rows - template.Rows + 1, source.Cols - template.Cols + 1, MatType.CV_32FC1)) {
                Cv2.MatchTemplate(source, template, result, TemplateMatchModes.CCoeffNormed);
                Cv2.MinMaxLoc(result, out _, out double maxVal, out _, out maxLoc);
                return maxVal >= threshold;
            }
        }

        /// <summary>
        /// Finds matching locations for template
        /// </summary>
        /// <param name="source">The source image</param>
        /// <param name="template">The image to match</param>
        /// <param name="result">A pre-allocated Mat to store the result in</param>
        /// <param name="threshold">A Normalized matching threshold. 0 means no match and 1 means full match.</param>
        /// <returns>A list of Y coordinates in the source image that matched the template</returns>
        private List<int> FindMatches(Mat source, Mat template, Mat result, float threshold) {
            Cv2.MatchTemplate(source, template, result, TemplateMatchModes.CCoeffNormed);
            var points = new List<int>();

            // This is the most efficient way to iterate over a Mat.
            unsafe {
                void DetectThreshold(float* value, int* pos) {
                    if (*value > threshold) {
                        // The first element of the pos array is the Y coordinate.
                        points.Add(pos[0]);
                    }
                }

                result.ForEachAsFloat(DetectThreshold);
            }

            return points;
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
                Hook?.Dispose();
                Hook = new Mat($@"resources\{res}\hook{IGUIScale.Text}.png");
                HookResult?.Dispose();
                HookResult = new Mat(leftmostFifth.Width - Hook.Width + 1, leftmostFifth.Height - Hook.Height + 1, MatType.CV_32FC1);

                Stage2?.Dispose();
                Stage2 = new Mat($@"resources\{res}\2stage{IGUIScale.Text}.png");
                Stage2Result?.Dispose();
                Stage2Result = new Mat(leftmostFifth.Width - Stage2.Width + 1, leftmostFifth.Height - Stage2.Height + 1, MatType.CV_32FC1);
            }

            if (!string.IsNullOrEmpty(UIScale.Text)) {
                Endgame?.Dispose();
                Endgame = new Mat($@"resources\{res}\endgame{UIScale.Text}.png");
                EndgameResult?.Dispose();
                EndgameResult = new Mat(leftmostFifth.Width - Endgame.Width + 1, leftmostFifth.Height - Endgame.Height + 1, MatType.CV_32FC1);
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
            using (var g = Graphics.FromImage(BmScreen)) {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                        Screen.PrimaryScreen.Bounds.Y,
                        0,
                        0,
                        leftmostFifth,
                        CopyPixelOperation.SourceCopy);
                BmScreen.ToMat(Frame);
            }

            // Check for first hook.
            var hookMatches = FindMatches(Frame, Hook, HookResult, LowerThreshCheckbox.Checked ? 0.8f : 0.9f);
            if (hookMatches.Any()) {
                hCount.AddRange(hookMatches);
                overlay.bHasDrawn = false;
            }

            var stage2Matches = FindMatches(Frame, Stage2, Stage2Result, 0.9f);
            if (stage2Matches.Any()) {
                _2stage.AddRange(stage2Matches);
                overlay.bHasDrawn = false;
            }

            // Check for endgame.
            if (MatchesTemplate(Frame, Endgame, EndgameResult, 0.9)) {
                overlay.G?.Clear(Color.Black);
                overlay.sList.Clear();
                overlay._2List.Clear();
                _2stage.Clear();
                hCount.Clear();
            }
        }
    }
}
