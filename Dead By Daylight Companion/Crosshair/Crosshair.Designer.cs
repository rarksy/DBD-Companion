namespace Dead_By_Daylight_Companion.Crosshair_Overlay {
    partial class Crosshair {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TitleBarPanel = new System.Windows.Forms.Panel();
            this.MinimizeHub = new System.Windows.Forms.Label();
            this.ExitHub = new System.Windows.Forms.Label();
            this.HubTitle = new System.Windows.Forms.Label();
            this.TitleBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleBarPanel
            // 
            this.TitleBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TitleBarPanel.Controls.Add(this.MinimizeHub);
            this.TitleBarPanel.Controls.Add(this.ExitHub);
            this.TitleBarPanel.Controls.Add(this.HubTitle);
            this.TitleBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBarPanel.Location = new System.Drawing.Point(0, 0);
            this.TitleBarPanel.Name = "TitleBarPanel";
            this.TitleBarPanel.Size = new System.Drawing.Size(289, 27);
            this.TitleBarPanel.TabIndex = 1;
            // 
            // MinimizeHub
            // 
            this.MinimizeHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeHub.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.MinimizeHub.ForeColor = System.Drawing.Color.Silver;
            this.MinimizeHub.Location = new System.Drawing.Point(247, 0);
            this.MinimizeHub.Name = "MinimizeHub";
            this.MinimizeHub.Size = new System.Drawing.Size(20, 23);
            this.MinimizeHub.TabIndex = 4;
            this.MinimizeHub.Text = "_";
            // 
            // ExitHub
            // 
            this.ExitHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitHub.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitHub.ForeColor = System.Drawing.Color.Silver;
            this.ExitHub.Location = new System.Drawing.Point(268, 4);
            this.ExitHub.Name = "ExitHub";
            this.ExitHub.Size = new System.Drawing.Size(18, 18);
            this.ExitHub.TabIndex = 5;
            this.ExitHub.Text = "X";
            // 
            // HubTitle
            // 
            this.HubTitle.Font = new System.Drawing.Font("Ebrima", 11.75F);
            this.HubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.HubTitle.Location = new System.Drawing.Point(93, 2);
            this.HubTitle.Name = "HubTitle";
            this.HubTitle.Size = new System.Drawing.Size(79, 27);
            this.HubTitle.TabIndex = 3;
            this.HubTitle.Text = "Crosshair";
            this.HubTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Crosshair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(289, 402);
            this.Controls.Add(this.TitleBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Crosshair";
            this.Text = "Crosshair";
            this.TitleBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBarPanel;
        private System.Windows.Forms.Label MinimizeHub;
        private System.Windows.Forms.Label ExitHub;
        private System.Windows.Forms.Label HubTitle;
    }
}