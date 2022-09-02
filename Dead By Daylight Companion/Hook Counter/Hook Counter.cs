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
            Disposed += new EventHandler(Hook_Counter_Disposed);
            InitializeComponent();
            ov.Show();
        }

        private void Hook_Counter_Disposed(object sender, EventArgs e) {
            BmScreen?.Dispose();
            Frame.Dispose();
            Hook.Dispose();
            Stage2.Dispose();
            Endgame.Dispose();
            HookResult.Dispose();
            Stage2Result.Dispose();
            EndgameResult.Dispose();
        }

        const int SRCCOPY = 0x00CC0020;
        enum FORMAT_MESSAGE : uint {
            ALLOCATE_BUFFER = 0x00000100,
            IGNORE_INSERTS = 0x00000200,
            FROM_SYSTEM = 0x00001000,
            ARGUMENT_ARRAY = 0x00002000,
            FROM_HMODULE = 0x00000800,
            FROM_STRING = 0x00000400
        }
        private int WindowWidth = 0, WindowHeight = 0;
        readonly overlay ov = new overlay();
        public static string res = Screen.PrimaryScreen.Bounds.Width.ToString() + Screen.PrimaryScreen.Bounds.Height.ToString(),
                             CurFontName = Properties.Settings.Default.FontName,
                             HookText;
        public static int CurFontSize = Properties.Settings.Default.FontSize;
        public static List<int> hCount = new List<int>();
        public static List<int> _2stage = new List<int>();
        private Bitmap BmScreen;
        private Mat Frame = new Mat(Screen.PrimaryScreen.Bounds.Size.Height, Screen.PrimaryScreen.Bounds.Size.Width, MatType.CV_8UC3),
            Hook, Stage2, Endgame, HookResult, Stage2Result, EndgameResult;
        private IntPtr GameWindow = IntPtr.Zero;
        private RECT WindowSize = new RECT();

        [DllImport("User32.dll")]
        extern static void ReleaseCapture();

        [DllImport("User32.dll")]
        extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        extern static bool IsWindow([In, Optional] IntPtr hWnd);

        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetClientRect([In] IntPtr hWnd, ref RECT lpRect);

        [DllImport("Gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool BitBlt(
            [In] IntPtr hdc,
            [In] int x,
            [In] int y,
            [In] int cx,
            [In] int cy,
            [In] IntPtr hdcSrc,
            [In] int x1,
            [In] int y1,
            [In] int rop);

        [DllImport("Kernel32.dll")]
        static extern int FormatMessage(
            [In] FORMAT_MESSAGE dwFlags,
            [In, Optional] IntPtr lpSource,
            [In] int dwMessageId,
            [In] int dwLanguageId,
            out StringBuilder lpBuffer,
            [In] int nSize,
            [In, Optional] IntPtr Arguments);

        [DllImport("Kernel32.dll")]
        static extern void SetLastError(uint dwErrCode);

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

        [Conditional("DEBUG")]
        [Conditional("TRACE")]
        public static void PrintErrorMessage(string staticMessage) {
#if DEBUG
            var sb = new StringBuilder(256);
            var written = FormatMessage(FORMAT_MESSAGE.FROM_SYSTEM
                | FORMAT_MESSAGE.ALLOCATE_BUFFER, IntPtr.Zero, Marshal.GetLastWin32Error(), 0, out sb, sb.Capacity);
            Debug.WriteLineIf(written > 0, sb.ToString().Substring(0, written));
#else
            Trace.TraceError(staticMessage);
#endif
        }

        private void Thread_Tick(object sender, EventArgs e) {
            void SearchForGame() {
                // Get the game process.
                var procs = Process.GetProcessesByName("DeadByDaylight-Win64-Shipping");
                var proc = procs.FirstOrDefault();

                // Could not find the process.
                if (proc == null) {
                    goto dispose;
                }

                if (proc.HasExited) {
                    Trace.TraceInformation("Game process has gone stale.");
                    goto dispose;
                }

                Trace.TraceInformation("Game process found.");
                GameWindow = proc.MainWindowHandle;

            dispose:
                foreach (var p in procs) {
                    p.Dispose();
                }
            }

            if (GameWindow.Equals(IntPtr.Zero)) {
                SearchForGame();
                return;
            }

            if (!IsWindow(GameWindow)) {
                Trace.TraceInformation("Game window closed.");
                GameWindow = IntPtr.Zero;
                ClearAll();
                SearchForGame();
                return;
            }

            // Get the dimensions of the game's client area.
            if (!GetClientRect(GameWindow, ref WindowSize)) {
                PrintErrorMessage("Failed to get size of client rect.");
                return;
            }

            // TODO: Position the overlay on top of the game.

            int oneFifth = WindowSize.right / 5;

            if (WindowSize.right != WindowWidth || WindowSize.bottom != WindowHeight) {
                WindowWidth = WindowSize.right;
                WindowHeight = WindowSize.bottom;
                Trace.TraceInformation("Game window resized to {0}x{1}.", WindowWidth, WindowHeight);
                Frame?.Dispose();
                Frame = new Mat(WindowSize.bottom, oneFifth, MatType.CV_8UC3);
                ResizeHookResults();
                ResizeEndGameResult();
                BmScreen?.Dispose();
                BmScreen = new Bitmap(oneFifth, WindowSize.bottom);
            }

            using (var gSrc = Graphics.FromHwnd(GameWindow))
            using (var gDst = Graphics.FromImage(BmScreen)) {
                IntPtr hdcSrc = gSrc.GetHdc();

                if (hdcSrc.Equals(IntPtr.Zero)) {
                    Trace.TraceError("Failed to acquire device context handle for game window.");
                    return;
                }

                IntPtr hdcDst = gDst.GetHdc();

                // Copy the pixels from the game window to an in-memory bitmap.
                bool success = BitBlt(hdcDst, 0, 0, oneFifth, WindowSize.bottom, hdcSrc, 0, 0, SRCCOPY);
                gSrc.ReleaseHdc(hdcSrc);
                gDst.ReleaseHdc(hdcDst);

                if (!success) {
                    PrintErrorMessage("BitBlt did not complete successfully.");
                    return;
                }

                BmScreen.ToMat(Frame);
            }

            // Check for first hook.
            var hookMatches = FindMatches(Frame, Hook, HookResult, LowerThreshCheckbox.Checked ? 0.8f : 0.9f);
            if (hookMatches.Any()) {
                Trace.TraceInformation("Hooked!");
                hCount.AddRange(hookMatches);
                overlay.bHasDrawn = false;
            }

            var stage2Matches = FindMatches(Frame, Stage2, Stage2Result, 0.9f);
            if (stage2Matches.Any()) {
                Trace.TraceInformation("Death hook!");
                _2stage.AddRange(stage2Matches);
                overlay.bHasDrawn = false;
            }

            // Check for endgame.
            if (MatchesTemplate(Frame, Endgame, EndgameResult, 0.9)) {
                Trace.TraceInformation("Game over.");
                ClearAll();
            }
        }

        private static void ClearAll() {
            overlay.G?.Clear(Color.Black);
            overlay.sList.Clear();
            overlay._2List.Clear();
            _2stage.Clear();
            hCount.Clear();
        }
    }
}
