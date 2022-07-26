using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Dead_By_Daylight_Companion {
    public partial class HubForm : Form {
        public HubForm() {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] public extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] public extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //TITLE BAR
        private void TitlePanel_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ExitHub_MouseEnter(object sender, EventArgs e) {
            ExitHub.ForeColor = Color.Red;
        }

        private void ExitHub_MouseLeave(object sender, EventArgs e) {
            ExitHub.ForeColor = Color.Silver;
        }

        private void ExitHub_MouseDown(object sender, MouseEventArgs e) {
            Environment.Exit(0);
        }

        private void MinimizeHub_MouseEnter(object sender, EventArgs e) {
            MinimizeHub.ForeColor = Color.Red;
        }

        private void MinimizeHub_MouseLeave(object sender, EventArgs e) {
            MinimizeHub.ForeColor = Color.Silver;
        }
        private void HubTitle_MouseDown(object sender, MouseEventArgs e) {
            TitlePanel_MouseDown(sender, e);
        }
        private void HubForm_Activated(object sender, EventArgs e) {
            this.Width = 477;
            this.Height = 292;
        }
        //END TITLE BAR

        private void ShowConfigEditor_MouseEnter(object sender, EventArgs e) {
            ShowConfigEditor.BackColor = Color.FromArgb(60,0,0);
        }

        private void ShowConfigEditor_MouseLeave(object sender, EventArgs e) {
            ShowConfigEditor.BackColor = Color.FromArgb(40,0,0);
        }

        private void ShowConfigEditor_Click(object sender, EventArgs e) {
            var t = new Thread(() => Application.Run(new Config_Editor.Config_Editor()));
            t.Start();
            this.Close();
        }

        private void ShowConfigEditor_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder(e.Graphics, this.HubPanel.ClientRectangle, Color.FromArgb(117, 43, 44), ButtonBorderStyle.Solid);
        }

        //END CONFIG EDITOR

        //HOOK COUNTER

        private void ShowHookCounter_MouseEnter(object sender, EventArgs e) {
            ShowHookCounter.BackColor = Color.FromArgb(60,0,0);
        }

        private void ShowHookCounter_MouseLeave(object sender, EventArgs e) {
            ShowHookCounter.BackColor = Color.FromArgb(40,0,0);
        }

        private void ShowHookCounter_Click(object sender, EventArgs e) {
            var t = new Thread(() => Application.Run(new Hook_Counter.Hook_Counter()));
            t.Start();
            this.Close();
        }

        private void ShowHookCounter_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder(e.Graphics, this.HubPanel.ClientRectangle, Color.FromArgb(117, 43, 44), ButtonBorderStyle.Solid);
        }
        //END HOOK COUNTER
        
        //FORM
        private void HubForm_Load(object sender, EventArgs e) {
            
        }
        //DISCORD
        private void Discord_MouseEnter(object sender, EventArgs e) {
            Discord.BackColor = Color.FromArgb(60,0,0);
        }

        private void Discord_MouseLeave(object sender, EventArgs e) {
            Discord.BackColor = Color.FromArgb(40,0,0);
        }

        private void Discord_Click(object sender, EventArgs e) {
            Process.Start("https://discord.gg/vKjjS8yazu");
        }
        //END DISCORD
        
        //GITHUB
        private void Github_MouseEnter(object sender, EventArgs e) {
            Github.BackColor = Color.FromArgb(60,0,0);
        }

        private void Github_MouseLeave(object sender, EventArgs e) {
            Github.BackColor = Color.FromArgb(40,0,0);
        }

        private void Github_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/rarksy/DBD-Companion");
        }

        //END GITHUB

        private void MinimizeHub_Click(object sender, EventArgs e) {
            for (int i = this.Width; i >= 0; i--) {
                this.Width -= 10;
                this.Height -= 10;
            }
            this.WindowState = FormWindowState.Minimized;
        }

        private void ExitHub_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }
    }
}
