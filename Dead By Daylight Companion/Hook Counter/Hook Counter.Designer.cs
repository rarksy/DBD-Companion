namespace Dead_By_Daylight_Companion.Hook_Counter {
    partial class Hook_Counter {
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
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.MinimizeHookCounter = new System.Windows.Forms.Label();
            this.ExitHookCounter = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SettingPanel = new System.Windows.Forms.Panel();
            this.UIScale = new System.Windows.Forms.ComboBox();
            this.IGUIScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Thread = new System.Windows.Forms.Timer(this.components);
            this.tTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.LowerThreshCheckbox = new System.Windows.Forms.CheckBox();
            this.ManualCycleLabel = new System.Windows.Forms.Label();
            this.ManualBindPanel = new System.Windows.Forms.Panel();
            this.BIND_S4 = new System.Windows.Forms.TextBox();
            this.BIND_S2 = new System.Windows.Forms.TextBox();
            this.BIND_S3 = new System.Windows.Forms.TextBox();
            this.BIND_S1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MHC_S1 = new System.Windows.Forms.Label();
            this.PlaySoundOnRenderCB = new System.Windows.Forms.CheckBox();
            this.SoundTextBox = new System.Windows.Forms.TextBox();
            this.ChangeSoundButton = new System.Windows.Forms.Button();
            this.sound_VolumeTB = new System.Windows.Forms.TrackBar();
            this.vol_label = new System.Windows.Forms.Label();
            this.KeypressTimer = new System.Windows.Forms.Timer(this.components);
            this.TitlePanel.SuspendLayout();
            this.SettingPanel.SuspendLayout();
            this.ManualBindPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sound_VolumeTB)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TitlePanel.Controls.Add(this.MinimizeHookCounter);
            this.TitlePanel.Controls.Add(this.ExitHookCounter);
            this.TitlePanel.Controls.Add(this.TitleLabel);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(477, 37);
            this.TitlePanel.TabIndex = 1;
            this.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
            // 
            // MinimizeHookCounter
            // 
            this.MinimizeHookCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeHookCounter.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold);
            this.MinimizeHookCounter.ForeColor = System.Drawing.Color.Silver;
            this.MinimizeHookCounter.Location = new System.Drawing.Point(428, 5);
            this.MinimizeHookCounter.Name = "MinimizeHookCounter";
            this.MinimizeHookCounter.Size = new System.Drawing.Size(20, 23);
            this.MinimizeHookCounter.TabIndex = 13;
            this.MinimizeHookCounter.Text = "_";
            this.MinimizeHookCounter.Click += new System.EventHandler(this.MinimizeHookCounter_Click);
            this.MinimizeHookCounter.MouseEnter += new System.EventHandler(this.MinimizeHookCounter_MouseEnter);
            this.MinimizeHookCounter.MouseLeave += new System.EventHandler(this.MinimizeHookCounter_MouseLeave);
            // 
            // ExitHookCounter
            // 
            this.ExitHookCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitHookCounter.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitHookCounter.ForeColor = System.Drawing.Color.Silver;
            this.ExitHookCounter.Location = new System.Drawing.Point(452, 9);
            this.ExitHookCounter.Name = "ExitHookCounter";
            this.ExitHookCounter.Size = new System.Drawing.Size(18, 18);
            this.ExitHookCounter.TabIndex = 14;
            this.ExitHookCounter.Text = "X";
            this.ExitHookCounter.Click += new System.EventHandler(this.ExitHookCounter_Click);
            this.ExitHookCounter.MouseEnter += new System.EventHandler(this.ExitHookCounter_MouseEnter);
            this.ExitHookCounter.MouseLeave += new System.EventHandler(this.ExitHookCounter_MouseLeave);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold);
            this.TitleLabel.ForeColor = System.Drawing.Color.Silver;
            this.TitleLabel.Location = new System.Drawing.Point(163, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(156, 19);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Hook Counter (Alpha)";
            this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            // 
            // SettingPanel
            // 
            this.SettingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SettingPanel.Controls.Add(this.UIScale);
            this.SettingPanel.Controls.Add(this.IGUIScale);
            this.SettingPanel.Controls.Add(this.label1);
            this.SettingPanel.Controls.Add(this.label2);
            this.SettingPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SettingPanel.Location = new System.Drawing.Point(305, 37);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.Size = new System.Drawing.Size(172, 247);
            this.SettingPanel.TabIndex = 2;
            // 
            // UIScale
            // 
            this.UIScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UIScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UIScale.ForeColor = System.Drawing.Color.Silver;
            this.UIScale.FormattingEnabled = true;
            this.UIScale.Items.AddRange(new object[] {
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.UIScale.Location = new System.Drawing.Point(3, 6);
            this.UIScale.Name = "UIScale";
            this.UIScale.Size = new System.Drawing.Size(50, 21);
            this.UIScale.TabIndex = 13;
            this.UIScale.SelectedIndexChanged += new System.EventHandler(this.UIScale_SelectedIndexChanged);
            // 
            // IGUIScale
            // 
            this.IGUIScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.IGUIScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IGUIScale.ForeColor = System.Drawing.Color.Silver;
            this.IGUIScale.FormattingEnabled = true;
            this.IGUIScale.Items.AddRange(new object[] {
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.IGUIScale.Location = new System.Drawing.Point(3, 33);
            this.IGUIScale.Name = "IGUIScale";
            this.IGUIScale.Size = new System.Drawing.Size(50, 21);
            this.IGUIScale.TabIndex = 14;
            this.IGUIScale.SelectedIndexChanged += new System.EventHandler(this.IGUIScale_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 10F);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(54, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "UI Scale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 10F);
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(54, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "In Game UI Scale";
            // 
            // Thread
            // 
            this.Thread.Interval = 500;
            this.Thread.Tick += new System.EventHandler(this.Thread_Tick);
            // 
            // tTooltip
            // 
            this.tTooltip.AutomaticDelay = 100;
            this.tTooltip.AutoPopDelay = 100000;
            this.tTooltip.InitialDelay = 100;
            this.tTooltip.ReshowDelay = 20;
            // 
            // LowerThreshCheckbox
            // 
            this.LowerThreshCheckbox.AutoSize = true;
            this.LowerThreshCheckbox.Font = new System.Drawing.Font("Ebrima", 10F);
            this.LowerThreshCheckbox.ForeColor = System.Drawing.Color.Silver;
            this.LowerThreshCheckbox.Location = new System.Drawing.Point(12, 43);
            this.LowerThreshCheckbox.Name = "LowerThreshCheckbox";
            this.LowerThreshCheckbox.Size = new System.Drawing.Size(192, 23);
            this.LowerThreshCheckbox.TabIndex = 17;
            this.LowerThreshCheckbox.Text = "Lower Detection Threshold";
            this.tTooltip.SetToolTip(this.LowerThreshCheckbox, "Lowers Detection Threshold If Detection Isnt Working (experimental)\r\n\r\n");
            this.LowerThreshCheckbox.UseVisualStyleBackColor = true;
            // 
            // ManualCycleLabel
            // 
            this.ManualCycleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ManualCycleLabel.AutoSize = true;
            this.ManualCycleLabel.Font = new System.Drawing.Font("Ebrima", 10F);
            this.ManualCycleLabel.ForeColor = System.Drawing.Color.Silver;
            this.ManualCycleLabel.Location = new System.Drawing.Point(80, 10);
            this.ManualCycleLabel.Name = "ManualCycleLabel";
            this.ManualCycleLabel.Size = new System.Drawing.Size(140, 19);
            this.ManualCycleLabel.TabIndex = 16;
            this.ManualCycleLabel.Text = "Manual Hook Cycling";
            this.tTooltip.SetToolTip(this.ManualCycleLabel, "Keybinds Disabled While Companion Is Focused");
            // 
            // ManualBindPanel
            // 
            this.ManualBindPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ManualBindPanel.Controls.Add(this.BIND_S4);
            this.ManualBindPanel.Controls.Add(this.BIND_S2);
            this.ManualBindPanel.Controls.Add(this.BIND_S3);
            this.ManualBindPanel.Controls.Add(this.BIND_S1);
            this.ManualBindPanel.Controls.Add(this.label5);
            this.ManualBindPanel.Controls.Add(this.label4);
            this.ManualBindPanel.Controls.Add(this.label3);
            this.ManualBindPanel.Controls.Add(this.MHC_S1);
            this.ManualBindPanel.Controls.Add(this.ManualCycleLabel);
            this.ManualBindPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ManualBindPanel.Location = new System.Drawing.Point(0, 184);
            this.ManualBindPanel.Name = "ManualBindPanel";
            this.ManualBindPanel.Size = new System.Drawing.Size(305, 100);
            this.ManualBindPanel.TabIndex = 22;
            // 
            // BIND_S4
            // 
            this.BIND_S4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BIND_S4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BIND_S4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BIND_S4.ForeColor = System.Drawing.Color.Silver;
            this.BIND_S4.Location = new System.Drawing.Point(230, 65);
            this.BIND_S4.MaxLength = 1;
            this.BIND_S4.Name = "BIND_S4";
            this.BIND_S4.Size = new System.Drawing.Size(31, 20);
            this.BIND_S4.TabIndex = 27;
            this.BIND_S4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BIND_S4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BIND_S4_KeyDown);
            // 
            // BIND_S2
            // 
            this.BIND_S2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BIND_S2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BIND_S2.ForeColor = System.Drawing.Color.Silver;
            this.BIND_S2.Location = new System.Drawing.Point(95, 65);
            this.BIND_S2.MaxLength = 1;
            this.BIND_S2.Name = "BIND_S2";
            this.BIND_S2.Size = new System.Drawing.Size(31, 20);
            this.BIND_S2.TabIndex = 26;
            this.BIND_S2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BIND_S2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BIND_S2_KeyDown);
            // 
            // BIND_S3
            // 
            this.BIND_S3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BIND_S3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BIND_S3.ForeColor = System.Drawing.Color.Silver;
            this.BIND_S3.Location = new System.Drawing.Point(162, 64);
            this.BIND_S3.MaxLength = 1;
            this.BIND_S3.Name = "BIND_S3";
            this.BIND_S3.Size = new System.Drawing.Size(31, 20);
            this.BIND_S3.TabIndex = 25;
            this.BIND_S3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BIND_S3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BIND_S3_KeyDown);
            // 
            // BIND_S1
            // 
            this.BIND_S1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BIND_S1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BIND_S1.ForeColor = System.Drawing.Color.Silver;
            this.BIND_S1.Location = new System.Drawing.Point(31, 65);
            this.BIND_S1.MaxLength = 1;
            this.BIND_S1.Name = "BIND_S1";
            this.BIND_S1.Size = new System.Drawing.Size(31, 20);
            this.BIND_S1.TabIndex = 24;
            this.BIND_S1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BIND_S1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BIND_S1_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 9F);
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(220, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Survivor 4";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 9F);
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(150, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Survivor 3";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 9F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(85, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Survivor 2";
            // 
            // MHC_S1
            // 
            this.MHC_S1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MHC_S1.AutoSize = true;
            this.MHC_S1.Font = new System.Drawing.Font("Ebrima", 9F);
            this.MHC_S1.ForeColor = System.Drawing.Color.Silver;
            this.MHC_S1.Location = new System.Drawing.Point(20, 46);
            this.MHC_S1.Name = "MHC_S1";
            this.MHC_S1.Size = new System.Drawing.Size(59, 15);
            this.MHC_S1.TabIndex = 17;
            this.MHC_S1.Text = "Survivor 1";
            // 
            // PlaySoundOnRenderCB
            // 
            this.PlaySoundOnRenderCB.AutoSize = true;
            this.PlaySoundOnRenderCB.Font = new System.Drawing.Font("Ebrima", 10F);
            this.PlaySoundOnRenderCB.ForeColor = System.Drawing.Color.Silver;
            this.PlaySoundOnRenderCB.Location = new System.Drawing.Point(12, 72);
            this.PlaySoundOnRenderCB.Name = "PlaySoundOnRenderCB";
            this.PlaySoundOnRenderCB.Size = new System.Drawing.Size(188, 23);
            this.PlaySoundOnRenderCB.TabIndex = 23;
            this.PlaySoundOnRenderCB.Text = "Play Sound When Hooked";
            this.PlaySoundOnRenderCB.UseVisualStyleBackColor = true;
            this.PlaySoundOnRenderCB.CheckedChanged += new System.EventHandler(this.PlaySoundOnRenderCB_CheckedChanged);
            // 
            // SoundTextBox
            // 
            this.SoundTextBox.Location = new System.Drawing.Point(12, 122);
            this.SoundTextBox.Multiline = true;
            this.SoundTextBox.Name = "SoundTextBox";
            this.SoundTextBox.ReadOnly = true;
            this.SoundTextBox.Size = new System.Drawing.Size(131, 17);
            this.SoundTextBox.TabIndex = 24;
            this.SoundTextBox.TextChanged += new System.EventHandler(this.SoundTextBox_TextChanged);
            // 
            // ChangeSoundButton
            // 
            this.ChangeSoundButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeSoundButton.Font = new System.Drawing.Font("Ebrima", 4F);
            this.ChangeSoundButton.ForeColor = System.Drawing.Color.White;
            this.ChangeSoundButton.Location = new System.Drawing.Point(149, 122);
            this.ChangeSoundButton.Name = "ChangeSoundButton";
            this.ChangeSoundButton.Size = new System.Drawing.Size(44, 17);
            this.ChangeSoundButton.TabIndex = 25;
            this.ChangeSoundButton.Text = ". . .";
            this.ChangeSoundButton.UseVisualStyleBackColor = true;
            this.ChangeSoundButton.Click += new System.EventHandler(this.ChangeSoundButton_Click);
            // 
            // sound_VolumeTB
            // 
            this.sound_VolumeTB.AutoSize = false;
            this.sound_VolumeTB.Location = new System.Drawing.Point(4, 98);
            this.sound_VolumeTB.Maximum = 100;
            this.sound_VolumeTB.Minimum = 10;
            this.sound_VolumeTB.Name = "sound_VolumeTB";
            this.sound_VolumeTB.Size = new System.Drawing.Size(104, 23);
            this.sound_VolumeTB.TabIndex = 26;
            this.sound_VolumeTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sound_VolumeTB.Value = 10;
            this.sound_VolumeTB.Scroll += new System.EventHandler(this.sound_VolumeTB_Scroll);
            // 
            // vol_label
            // 
            this.vol_label.AutoSize = true;
            this.vol_label.Font = new System.Drawing.Font("Ebrima", 10F);
            this.vol_label.ForeColor = System.Drawing.Color.Silver;
            this.vol_label.Location = new System.Drawing.Point(101, 98);
            this.vol_label.Name = "vol_label";
            this.vol_label.Size = new System.Drawing.Size(99, 19);
            this.vol_label.TabIndex = 27;
            this.vol_label.Text = "Sound Volume";
            this.vol_label.Click += new System.EventHandler(this.label6_Click);
            // 
            // KeypressTimer
            // 
            this.KeypressTimer.Interval = 500;
            this.KeypressTimer.Tick += new System.EventHandler(this.KeypressTimer_Tick);
            // 
            // Hook_Counter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(477, 284);
            this.Controls.Add(this.vol_label);
            this.Controls.Add(this.sound_VolumeTB);
            this.Controls.Add(this.ChangeSoundButton);
            this.Controls.Add(this.SoundTextBox);
            this.Controls.Add(this.PlaySoundOnRenderCB);
            this.Controls.Add(this.ManualBindPanel);
            this.Controls.Add(this.LowerThreshCheckbox);
            this.Controls.Add(this.SettingPanel);
            this.Controls.Add(this.TitlePanel);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Hook_Counter";
            this.Text = "Hook_Counter";
            this.Activated += new System.EventHandler(this.Hook_Counter_Activated);
            this.Load += new System.EventHandler(this.Hook_Counter_Load);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.SettingPanel.ResumeLayout(false);
            this.SettingPanel.PerformLayout();
            this.ManualBindPanel.ResumeLayout(false);
            this.ManualBindPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sound_VolumeTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Panel SettingPanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Timer Thread;
        private System.Windows.Forms.ToolTip tTooltip;
        private System.Windows.Forms.Label MinimizeHookCounter;
        private System.Windows.Forms.Label ExitHookCounter;
        private System.Windows.Forms.ComboBox IGUIScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox LowerThreshCheckbox;
        private System.Windows.Forms.Panel ManualBindPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label MHC_S1;
        private System.Windows.Forms.Label ManualCycleLabel;
        private System.Windows.Forms.TextBox BIND_S4;
        private System.Windows.Forms.TextBox BIND_S2;
        private System.Windows.Forms.TextBox BIND_S3;
        private System.Windows.Forms.TextBox BIND_S1;
        public System.Windows.Forms.ComboBox UIScale;
        private System.Windows.Forms.CheckBox PlaySoundOnRenderCB;
        private System.Windows.Forms.Button ChangeSoundButton;
        private System.Windows.Forms.Label vol_label;
        public System.Windows.Forms.TrackBar sound_VolumeTB;
        public System.Windows.Forms.TextBox SoundTextBox;
        private System.Windows.Forms.Timer KeypressTimer;
    }
}