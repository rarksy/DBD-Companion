using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            ExitHub.BackColor = Color.FromArgb(107, 13, 14);
        }

        private void ExitHub_MouseLeave(object sender, EventArgs e) {
            ExitHub.BackColor = Color.FromArgb(87, 13, 14);
        }

        private void ExitHub_MouseDown(object sender, MouseEventArgs e) {
            Environment.Exit(0);
        }

        private void MinimizeHub_MouseEnter(object sender, EventArgs e) {
            MinimizeHub.BackColor = Color.FromArgb(107, 13, 14);
        }

        private void MinimizeHub_MouseLeave(object sender, EventArgs e) {
            MinimizeHub.BackColor = Color.FromArgb(87, 13, 14);
        }

        private void MinimizeHub_MouseDown(object sender, MouseEventArgs e) {
            for (int i = this.Height; i >= 0; i--) {
                this.Height -= 3;
            }
            this.WindowState = FormWindowState.Minimized;
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
            ShowConfigEditor.BackColor = Color.FromArgb(107, 13, 14);
        }

        private void ShowConfigEditor_MouseLeave(object sender, EventArgs e) {
            ShowConfigEditor.BackColor = Color.FromArgb(87, 13, 14);
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
            ShowHookCounter.BackColor = Color.FromArgb(107, 13, 14);
        }

        private void ShowHookCounter_MouseLeave(object sender, EventArgs e) {
            ShowHookCounter.BackColor = Color.FromArgb(87, 13, 14);
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
            Discord.BackColor = Color.FromArgb(107, 13, 14);
        }

        private void Discord_MouseLeave(object sender, EventArgs e) {
            Discord.BackColor = Color.FromArgb(87, 13, 14);
        }

        private void Discord_Click(object sender, EventArgs e) {
            Process.Start("https://discord.gg/vKjjS8yazu");
        }
        //END DISCORD
        
        //GITHUB
        private void Github_MouseEnter(object sender, EventArgs e) {
            Github.BackColor = Color.FromArgb(107, 13, 14);
        }

        private void Github_MouseLeave(object sender, EventArgs e) {
            Github.BackColor = Color.FromArgb(87, 13, 14);
        }

        private void Github_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/rarksy/DBD-Companion");
        }

        //END GITHUB
    }
}
