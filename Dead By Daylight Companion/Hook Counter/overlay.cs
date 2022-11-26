using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dead_By_Daylight_Companion.Hook_Counter {
    public partial class overlay : Form {
        public overlay() {
            InitializeComponent();
        }

        public static bool bHasDrawn = true;
        public static int s1, s2, s3, s4;
        public static Graphics G, G2, G3, G4;
        Image hook_pip = Image.FromFile(@"resources\hook_pip.png");
        [DllImport("user32.dll", SetLastError = true)] public static extern int GetWindowLongPtr(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")] public static extern int SetWindowLongPtr(IntPtr hWnd, int nIndex, int dwNewLong);

        private void OverlayLoad(object sender, EventArgs e) {
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width / 5;
            ShowInTaskbar = false;
            Location = new Point(0, 0);
            TopMost = true;
            int initStyle = GetWindowLongPtr(this.Handle, -20);
            SetWindowLongPtr(this.Handle, -20, initStyle | 0x20);
            G = CreateGraphics();
            G2 = CreateGraphics();
            G3 = CreateGraphics();
            G4 = CreateGraphics();
            DrawTimer.Start();
        }
        private NAudio.Wave.WaveOutEvent outputDevice;
        private NAudio.Wave.AudioFileReader audioFile;


        private void DrawTimerTick(object sender, EventArgs e) {
            
            if (!bHasDrawn) {
                //-- First Hook
                if (s1 == 0) {
                    G.DrawImage(hook_pip, new Point(170, Hook_Counter.survs[0] - 10));
                    s1 = 1;
                }
                if (s2 == 0 && Hook_Counter.survs[1] != 0) {
                    G2.DrawImage(hook_pip, new Point(170, Hook_Counter.survs[1] - 10));
                    s2 = 1;
                }
                if (s3 == 0 && Hook_Counter.survs[2] != 0) {
                    G3.DrawImage(hook_pip, new Point(170, Hook_Counter.survs[2] - 10));
                    s3 = 1;
                }
                if (s4 == 0 && Hook_Counter.survs[3] != 0) {
                    G4.DrawImage(hook_pip, new Point(170, Hook_Counter.survs[3] - 10));
                    s4 = 1;
                }
                //-- First Hook

                //-- Second Hook
                if (s1 == 1 && Hook_Counter.survs_secondstage[0] != 0) {
                    G.DrawImage(hook_pip, new Point(180, Hook_Counter.bUpdated ? Hook_Counter.survs_secondstage[0] - 10 : Hook_Counter.survs_secondstage[0] - 45));
                    s1 = 2;
                }
                if (s2 == 1 && Hook_Counter.survs_secondstage[1] != 0) {
                    G2.DrawImage(hook_pip, new Point(180, Hook_Counter.bUpdated ? Hook_Counter.survs_secondstage[1] - 10 : Hook_Counter.survs_secondstage[1] - 45));
                    s2 = 2;
                }
                if (s3 == 1 && Hook_Counter.survs_secondstage[2] != 0) {
                    G3.DrawImage(hook_pip, new Point(180, Hook_Counter.bUpdated ? Hook_Counter.survs_secondstage[2] - 10 : Hook_Counter.survs_secondstage[2] - 45));
                    s3 = 2;
                }
                if (s4 == 1 && Hook_Counter.survs_secondstage[3] != 0) {
                    G4.DrawImage(hook_pip, new Point(180, Hook_Counter.bUpdated ? Hook_Counter.survs_secondstage[3] - 10 : Hook_Counter.survs_secondstage[3] - 45));
                    s4 = 2;
                }

                if (Properties.Settings.Default.bPlaySound && Properties.Settings.Default.sSoundLocation != "") {
                    if (outputDevice == null) {
                        outputDevice = new NAudio.Wave.WaveOutEvent();
                    }
                    audioFile = new NAudio.Wave.AudioFileReader(Properties.Settings.Default.sSoundLocation);
                    if (outputDevice.PlaybackState != NAudio.Wave.PlaybackState.Playing) {
                        outputDevice.Init(audioFile);
                        outputDevice.Volume = Properties.Settings.Default.iSoundVolume / 100f;
                        outputDevice.Play();
                    }
                }

                bHasDrawn = true;
            }
        }
    }
}