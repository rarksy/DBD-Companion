﻿namespace Dead_By_Daylight_Companion {
    partial class HubForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HubForm));
            this.TitleBarPanel = new System.Windows.Forms.Panel();
            this.MinimizeHub = new System.Windows.Forms.Label();
            this.ExitHub = new System.Windows.Forms.Label();
            this.HubTitle = new System.Windows.Forms.Label();
            this.ShowHookCounter = new System.Windows.Forms.PictureBox();
            this.ShowConfigEditor = new System.Windows.Forms.PictureBox();
            this.CreditLabel = new System.Windows.Forms.Label();
            this.HubPanel = new System.Windows.Forms.Panel();
            this.ShowXHair = new System.Windows.Forms.PictureBox();
            this.HubToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Discord = new System.Windows.Forms.PictureBox();
            this.Github = new System.Windows.Forms.PictureBox();
            this.DonationPicBox = new System.Windows.Forms.PictureBox();
            this.SocialPanel = new System.Windows.Forms.Panel();
            this.Position_Timer = new System.Windows.Forms.Timer(this.components);
            this.TitleBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowHookCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowConfigEditor)).BeginInit();
            this.HubPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowXHair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Discord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Github)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonationPicBox)).BeginInit();
            this.SocialPanel.SuspendLayout();
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
            this.TitleBarPanel.Size = new System.Drawing.Size(477, 27);
            this.TitleBarPanel.TabIndex = 0;
            this.TitleBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
            // 
            // MinimizeHub
            // 
            this.MinimizeHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeHub.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.MinimizeHub.ForeColor = System.Drawing.Color.Silver;
            this.MinimizeHub.Location = new System.Drawing.Point(431, 0);
            this.MinimizeHub.Name = "MinimizeHub";
            this.MinimizeHub.Size = new System.Drawing.Size(20, 23);
            this.MinimizeHub.TabIndex = 4;
            this.MinimizeHub.Text = "_";
            this.MinimizeHub.Click += new System.EventHandler(this.MinimizeHub_Click);
            this.MinimizeHub.MouseEnter += new System.EventHandler(this.MinimizeHub_MouseEnter);
            this.MinimizeHub.MouseLeave += new System.EventHandler(this.MinimizeHub_MouseLeave);
            // 
            // ExitHub
            // 
            this.ExitHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitHub.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitHub.ForeColor = System.Drawing.Color.Silver;
            this.ExitHub.Location = new System.Drawing.Point(452, 4);
            this.ExitHub.Name = "ExitHub";
            this.ExitHub.Size = new System.Drawing.Size(18, 18);
            this.ExitHub.TabIndex = 5;
            this.ExitHub.Text = "X";
            this.ExitHub.Click += new System.EventHandler(this.ExitHub_Click);
            this.ExitHub.MouseEnter += new System.EventHandler(this.ExitHub_MouseEnter);
            this.ExitHub.MouseLeave += new System.EventHandler(this.ExitHub_MouseLeave);
            // 
            // HubTitle
            // 
            this.HubTitle.Font = new System.Drawing.Font("Ebrima", 11.75F);
            this.HubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.HubTitle.Location = new System.Drawing.Point(-4, 2);
            this.HubTitle.Name = "HubTitle";
            this.HubTitle.Size = new System.Drawing.Size(220, 27);
            this.HubTitle.TabIndex = 3;
            this.HubTitle.Text = "Dead By Daylight Companion";
            this.HubTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HubTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HubTitle_MouseDown);
            // 
            // ShowHookCounter
            // 
            this.ShowHookCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ShowHookCounter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShowHookCounter.Image = ((System.Drawing.Image)(resources.GetObject("ShowHookCounter.Image")));
            this.ShowHookCounter.Location = new System.Drawing.Point(0, 0);
            this.ShowHookCounter.Name = "ShowHookCounter";
            this.ShowHookCounter.Size = new System.Drawing.Size(136, 51);
            this.ShowHookCounter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShowHookCounter.TabIndex = 1;
            this.ShowHookCounter.TabStop = false;
            this.HubToolTip.SetToolTip(this.ShowHookCounter, "Hook Counter");
            this.ShowHookCounter.Click += new System.EventHandler(this.ShowHookCounter_Click);
            this.ShowHookCounter.Paint += new System.Windows.Forms.PaintEventHandler(this.ShowHookCounter_Paint);
            this.ShowHookCounter.MouseEnter += new System.EventHandler(this.ShowHookCounter_MouseEnter);
            this.ShowHookCounter.MouseLeave += new System.EventHandler(this.ShowHookCounter_MouseLeave);
            // 
            // ShowConfigEditor
            // 
            this.ShowConfigEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ShowConfigEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShowConfigEditor.Image = ((System.Drawing.Image)(resources.GetObject("ShowConfigEditor.Image")));
            this.ShowConfigEditor.Location = new System.Drawing.Point(0, 51);
            this.ShowConfigEditor.Name = "ShowConfigEditor";
            this.ShowConfigEditor.Size = new System.Drawing.Size(136, 51);
            this.ShowConfigEditor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShowConfigEditor.TabIndex = 5;
            this.ShowConfigEditor.TabStop = false;
            this.HubToolTip.SetToolTip(this.ShowConfigEditor, "Config Editor");
            this.ShowConfigEditor.Click += new System.EventHandler(this.ShowConfigEditor_Click);
            this.ShowConfigEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.ShowConfigEditor_Paint);
            this.ShowConfigEditor.MouseEnter += new System.EventHandler(this.ShowConfigEditor_MouseEnter);
            this.ShowConfigEditor.MouseLeave += new System.EventHandler(this.ShowConfigEditor_MouseLeave);
            // 
            // CreditLabel
            // 
            this.CreditLabel.Font = new System.Drawing.Font("Ebrima", 11.75F);
            this.CreditLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.CreditLabel.Location = new System.Drawing.Point(3, 9);
            this.CreditLabel.Name = "CreditLabel";
            this.CreditLabel.Size = new System.Drawing.Size(141, 27);
            this.CreditLabel.TabIndex = 7;
            this.CreditLabel.Text = "Created By Rarksy";
            this.CreditLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HubPanel
            // 
            this.HubPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HubPanel.Controls.Add(this.ShowXHair);
            this.HubPanel.Controls.Add(this.ShowConfigEditor);
            this.HubPanel.Controls.Add(this.ShowHookCounter);
            this.HubPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.HubPanel.Location = new System.Drawing.Point(0, 27);
            this.HubPanel.Name = "HubPanel";
            this.HubPanel.Size = new System.Drawing.Size(136, 265);
            this.HubPanel.TabIndex = 8;
            // 
            // ShowXHair
            // 
            this.ShowXHair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ShowXHair.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShowXHair.Image = ((System.Drawing.Image)(resources.GetObject("ShowXHair.Image")));
            this.ShowXHair.Location = new System.Drawing.Point(0, 102);
            this.ShowXHair.Name = "ShowXHair";
            this.ShowXHair.Size = new System.Drawing.Size(136, 51);
            this.ShowXHair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ShowXHair.TabIndex = 6;
            this.ShowXHair.TabStop = false;
            this.HubToolTip.SetToolTip(this.ShowXHair, "Crosshair Overlay");
            this.ShowXHair.Visible = false;
            this.ShowXHair.Click += new System.EventHandler(this.ShowXHair_Click);
            // 
            // HubToolTip
            // 
            this.HubToolTip.AutomaticDelay = 100;
            this.HubToolTip.AutoPopDelay = 1000000;
            this.HubToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(3)))), ((int)(((byte)(4)))));
            this.HubToolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.HubToolTip.InitialDelay = 100;
            this.HubToolTip.ReshowDelay = 20;
            // 
            // Discord
            // 
            this.Discord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Discord.Image = ((System.Drawing.Image)(resources.GetObject("Discord.Image")));
            this.Discord.Location = new System.Drawing.Point(306, 4);
            this.Discord.Name = "Discord";
            this.Discord.Size = new System.Drawing.Size(32, 32);
            this.Discord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Discord.TabIndex = 6;
            this.Discord.TabStop = false;
            this.HubToolTip.SetToolTip(this.Discord, "Join The Discord!");
            this.Discord.Click += new System.EventHandler(this.Discord_Click);
            this.Discord.MouseEnter += new System.EventHandler(this.Discord_MouseEnter);
            this.Discord.MouseLeave += new System.EventHandler(this.Discord_MouseLeave);
            // 
            // Github
            // 
            this.Github.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Github.Image = ((System.Drawing.Image)(resources.GetObject("Github.Image")));
            this.Github.Location = new System.Drawing.Point(268, 4);
            this.Github.Name = "Github";
            this.Github.Size = new System.Drawing.Size(32, 32);
            this.Github.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Github.TabIndex = 7;
            this.Github.TabStop = false;
            this.HubToolTip.SetToolTip(this.Github, "Visit The Github!");
            this.Github.Click += new System.EventHandler(this.Github_Click);
            this.Github.MouseEnter += new System.EventHandler(this.Github_MouseEnter);
            this.Github.MouseLeave += new System.EventHandler(this.Github_MouseLeave);
            // 
            // DonationPicBox
            // 
            this.DonationPicBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DonationPicBox.Image = ((System.Drawing.Image)(resources.GetObject("DonationPicBox.Image")));
            this.DonationPicBox.Location = new System.Drawing.Point(230, 4);
            this.DonationPicBox.Name = "DonationPicBox";
            this.DonationPicBox.Size = new System.Drawing.Size(32, 32);
            this.DonationPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DonationPicBox.TabIndex = 8;
            this.DonationPicBox.TabStop = false;
            this.HubToolTip.SetToolTip(this.DonationPicBox, "Support Rarksy!");
            this.DonationPicBox.Click += new System.EventHandler(this.DonationPicBox_Click);
            // 
            // SocialPanel
            // 
            this.SocialPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SocialPanel.Controls.Add(this.DonationPicBox);
            this.SocialPanel.Controls.Add(this.Github);
            this.SocialPanel.Controls.Add(this.Discord);
            this.SocialPanel.Controls.Add(this.CreditLabel);
            this.SocialPanel.Location = new System.Drawing.Point(136, 252);
            this.SocialPanel.Name = "SocialPanel";
            this.SocialPanel.Size = new System.Drawing.Size(341, 40);
            this.SocialPanel.TabIndex = 9;
            // 
            // Position_Timer
            // 
            this.Position_Timer.Tick += new System.EventHandler(this.Position_Timer_Tick);
            // 
            // HubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(477, 292);
            this.Controls.Add(this.SocialPanel);
            this.Controls.Add(this.HubPanel);
            this.Controls.Add(this.TitleBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HubForm";
            this.Opacity = 0.95D;
            this.Text = "Dead By Daylight Companion";
            this.Activated += new System.EventHandler(this.HubForm_Activated);
            this.Load += new System.EventHandler(this.HubForm_Load);
            this.TitleBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShowHookCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowConfigEditor)).EndInit();
            this.HubPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShowXHair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Discord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Github)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonationPicBox)).EndInit();
            this.SocialPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBarPanel;
        private System.Windows.Forms.Label HubTitle;
        private System.Windows.Forms.PictureBox ShowHookCounter;
        private System.Windows.Forms.PictureBox ShowConfigEditor;
        private System.Windows.Forms.Label CreditLabel;
        private System.Windows.Forms.ToolTip HubToolTip;
        private System.Windows.Forms.Panel HubPanel;
        private System.Windows.Forms.Panel SocialPanel;
        private System.Windows.Forms.PictureBox Discord;
        private System.Windows.Forms.PictureBox Github;
        private System.Windows.Forms.Label MinimizeHub;
        private System.Windows.Forms.Label ExitHub;
        private System.Windows.Forms.PictureBox ShowXHair;
        private System.Windows.Forms.PictureBox DonationPicBox;
        private System.Windows.Forms.Timer Position_Timer;
    }
}

