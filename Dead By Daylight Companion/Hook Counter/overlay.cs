using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dead_By_Daylight_Companion.Hook_Counter {
    public partial class overlay : Form {
        public overlay() {
            InitializeComponent();
        }

        const int WS_EX_TRANSPARENT = 0x20;
        public static bool bHasDrawn = false;
        public static List<int> sList = new List<int>();
        public static List<int> _2List = new List<int>();
        public static Graphics G;
        [DllImport("user32.dll", SetLastError = true)] public static extern int GetWindowLongPtr(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")] public static extern int SetWindowLongPtr(IntPtr hWnd, int nIndex, int dwNewLong);

        private void OverlayLoad(object sender, EventArgs e) {
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width / 5;
            ShowInTaskbar = false;
            Location = new Point(0, 0);
            TopMost = true;
            int initStyle = GetWindowLongPtr(this.Handle, -20);
            SetWindowLongPtr(this.Handle, -20, initStyle | WS_EX_TRANSPARENT);

            DrawTimer.Start();
        }

        private void DrawTimerTick(object sender, EventArgs e) {
            if (!bHasDrawn) {
                G = this.CreateGraphics();
                for (int i = 0; i < Hook_Counter.hCount.Count; i++) {
                    int j = Hook_Counter.hCount[i];
                    if (!sList.Contains(j)) {
                        sList.Add(j);
                        G.DrawString(Hook_Counter.HookText, new Font(Hook_Counter.CurFontName, Hook_Counter.CurFontSize), new SolidBrush(Color.White), 170.0F, j);
                    }
                }
                if (Hook_Counter.HookText == "I") {
                    for (int k = 0; k < Hook_Counter._2stage.Count; k++) {
                        int l = Hook_Counter._2stage[k];
                        if (!_2List.Contains(l)) {
                            _2List.Add(l);
                            G.DrawString("I", new Font(Hook_Counter.CurFontName, Hook_Counter.CurFontSize), new SolidBrush(Color.White), 178.0F, l - 47.0F);
                        }
                    }
                }
                bHasDrawn = true;
            }
        }
    }
}
