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

namespace Dead_By_Daylight_Companion.Hook_Counter {
    public partial class Hook_Counter : Form {
        public Hook_Counter() {
            InitializeComponent();
            ov.Show();
        }

        readonly overlay ov = new overlay();
        public static string res = Screen.PrimaryScreen.Bounds.Width.ToString() + Screen.PrimaryScreen.Bounds.Height.ToString(),
                             CurFontName = Properties.Settings.Default.FontName,
                             HookText;
        public static int CurFontSize = Properties.Settings.Default.FontSize;
        public static List<int> hCount = new List<int>();
        public static List<int> _2stage = new List<int>();
        private Mat Frame = new Mat(Screen.PrimaryScreen.Bounds.Size.Height, Screen.PrimaryScreen.Bounds.Size.Width, MatType.CV_8UC3),
            Hook, Stage2, Endgame, HookResult, Stage2Result, EndgameResult;

        [DllImport("User32.dll")]
        extern static void ReleaseCapture();

        [DllImport("User32.dll")]
        extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ExitHookCounter_Click(object sender, EventArgs e) {
            Application.Exit();
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

        private bool FindMatch(Mat source, Mat template, double threshold, out OpenCvSharp.Point maxLoc) {
            using (var result = new Mat(source.Rows - template.Rows + 1, source.Cols - template.Cols + 1, MatType.CV_32FC1)) {
                Cv2.MatchTemplate(source, template, result, TemplateMatchModes.CCoeffNormed);
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

        private void Hook_Counter_KeyDown(object sender, KeyEventArgs e) {

        }


        private void BIND_S1_KeyDown(object sender, KeyEventArgs e) {
            Keys k1 = new Keys();
            Register_KeyBind(out k1, e, BIND_S1);
            Properties.Settings.Default.S1_BIND = k1;
            Properties.Settings.Default.Save();
        }


        private void BIND_S2_KeyDown(object sender, KeyEventArgs e) {
            Keys k2 = new Keys();
            Register_KeyBind(out k2, e, BIND_S2);
            Properties.Settings.Default.S2_BIND = k2;
            Properties.Settings.Default.Save();
        }

        private void BIND_S3_KeyDown(object sender, KeyEventArgs e) {
            Keys k3 = new Keys();
            Register_KeyBind(out k3, e, BIND_S3);
            Properties.Settings.Default.S3_BIND = k3;
            Properties.Settings.Default.Save();
        }

        private void BIND_S4_KeyDown(object sender, KeyEventArgs e) {
            Keys k4 = new Keys();
            Register_KeyBind(out k4, e, BIND_S4);
            Properties.Settings.Default.S4_BIND = k4;
            Properties.Settings.Default.Save();
        }

        private void Register_KeyBind(out Keys _var, KeyEventArgs e, TextBox tb) {
            _var = 0;
            if (e.KeyData == Keys.LWin || e.KeyData == Keys.RWin || e.KeyData == Keys.Escape) return;
            _var = Keys.KeyCode;
            tb.Text = e.KeyData.ToString();
            this.ActiveControl = null;
        }

        private void ReloadRes() {
            if (!string.IsNullOrEmpty(IGUIScale.Text)) {
                Hook?.Dispose();
                Hook = new Mat($@"resources\{res}\hook{IGUIScale.Text}.png");
                Stage2?.Dispose();
                Stage2 = new Mat($@"resources\{res}\2stage{IGUIScale.Text}.png");
                ResizeHookResults();
            }

            if (!string.IsNullOrEmpty(UIScale.Text)) {
                Endgame?.Dispose();
                Endgame = new Mat($@"resources\{res}\endgame{UIScale.Text}.png");
                ResizeEndGameResult();
            }
        }

        private void ResizeEndGameResult() {
            EndgameResult?.Dispose();
            EndgameResult = new Mat(Frame.Rows - Endgame.Rows + 1, Frame.Cols - Endgame.Cols + 1, MatType.CV_32FC1);
        }

        private void ResizeHookResults() {
            HookResult?.Dispose();
            HookResult = new Mat(Frame.Rows - Hook.Rows + 1, Frame.Cols - Hook.Cols + 1, MatType.CV_32FC1);
            Stage2Result?.Dispose();
            Stage2Result = new Mat(Frame.Rows - Stage2.Rows + 1, Frame.Cols - Stage2.Cols + 1, MatType.CV_32FC1);
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

           
        }

    }
}
