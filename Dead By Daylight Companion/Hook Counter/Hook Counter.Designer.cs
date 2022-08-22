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
            this.ChangeFont = new System.Windows.Forms.Button();
            this.Thread = new System.Windows.Forms.Timer(this.components);
            this.tTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.LowerThreshCheckbox = new System.Windows.Forms.CheckBox();
            this.UIScale = new System.Windows.Forms.ComboBox();
            this.IGUIScale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FontLabel = new System.Windows.Forms.Label();
            this.FontSizeLabel = new System.Windows.Forms.Label();
            this.HookTextBox = new System.Windows.Forms.TextBox();
            this.Hooked_Text_Label = new System.Windows.Forms.Label();
            this.CountStageCB = new System.Windows.Forms.CheckBox();
            this.TitlePanel.SuspendLayout();
            this.SettingPanel.SuspendLayout();
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
            this.TitlePanel.Size = new System.Drawing.Size(475, 37);
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
            this.SettingPanel.Controls.Add(this.ChangeFont);
            this.SettingPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SettingPanel.Location = new System.Drawing.Point(303, 37);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.Size = new System.Drawing.Size(172, 370);
            this.SettingPanel.TabIndex = 2;
            // 
            // ChangeFont
            // 
            this.ChangeFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChangeFont.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChangeFont.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChangeFont.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChangeFont.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChangeFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeFont.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold);
            this.ChangeFont.ForeColor = System.Drawing.Color.Silver;
            this.ChangeFont.Location = new System.Drawing.Point(0, 0);
            this.ChangeFont.Name = "ChangeFont";
            this.ChangeFont.Size = new System.Drawing.Size(172, 37);
            this.ChangeFont.TabIndex = 13;
            this.ChangeFont.Text = "Change Font";
            this.ChangeFont.UseVisualStyleBackColor = false;
            this.ChangeFont.Click += new System.EventHandler(this.ChangeFont_Click);
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
            this.LowerThreshCheckbox.Location = new System.Drawing.Point(13, 127);
            this.LowerThreshCheckbox.Name = "LowerThreshCheckbox";
            this.LowerThreshCheckbox.Size = new System.Drawing.Size(192, 23);
            this.LowerThreshCheckbox.TabIndex = 17;
            this.LowerThreshCheckbox.Text = "Lower Detection Threshold";
            this.tTooltip.SetToolTip(this.LowerThreshCheckbox, "Lowers Detection Threshold If Detection Isnt Working (experimental)\r\n\r\n");
            this.LowerThreshCheckbox.UseVisualStyleBackColor = true;
            // 
            // UIScale
            // 
            this.UIScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UIScale.FormattingEnabled = true;
            this.UIScale.Items.AddRange(new object[] {
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.UIScale.Location = new System.Drawing.Point(13, 72);
            this.UIScale.Name = "UIScale";
            this.UIScale.Size = new System.Drawing.Size(50, 21);
            this.UIScale.TabIndex = 13;
            this.UIScale.SelectedIndexChanged += new System.EventHandler(this.UIScale_SelectedIndexChanged);
            // 
            // IGUIScale
            // 
            this.IGUIScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IGUIScale.FormattingEnabled = true;
            this.IGUIScale.Items.AddRange(new object[] {
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.IGUIScale.Location = new System.Drawing.Point(13, 99);
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
            this.label1.Location = new System.Drawing.Point(69, 74);
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
            this.label2.Location = new System.Drawing.Point(69, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "In Game UI Scale";
            // 
            // FontLabel
            // 
            this.FontLabel.AutoSize = true;
            this.FontLabel.Font = new System.Drawing.Font("Ebrima", 10F);
            this.FontLabel.ForeColor = System.Drawing.Color.Silver;
            this.FontLabel.Location = new System.Drawing.Point(9, 353);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(44, 19);
            this.FontLabel.TabIndex = 14;
            this.FontLabel.Text = "Font: ";
            // 
            // FontSizeLabel
            // 
            this.FontSizeLabel.AutoSize = true;
            this.FontSizeLabel.Font = new System.Drawing.Font("Ebrima", 10F);
            this.FontSizeLabel.ForeColor = System.Drawing.Color.Silver;
            this.FontSizeLabel.Location = new System.Drawing.Point(9, 376);
            this.FontSizeLabel.Name = "FontSizeLabel";
            this.FontSizeLabel.Size = new System.Drawing.Size(71, 19);
            this.FontSizeLabel.TabIndex = 15;
            this.FontSizeLabel.Text = "Font Size: ";
            // 
            // HookTextBox
            // 
            this.HookTextBox.Location = new System.Drawing.Point(13, 48);
            this.HookTextBox.Name = "HookTextBox";
            this.HookTextBox.Size = new System.Drawing.Size(166, 20);
            this.HookTextBox.TabIndex = 19;
            this.HookTextBox.Text = "Hooked";
            this.HookTextBox.TextChanged += new System.EventHandler(this.HookTextBox_TextChanged);
            // 
            // Hooked_Text_Label
            // 
            this.Hooked_Text_Label.AutoSize = true;
            this.Hooked_Text_Label.Font = new System.Drawing.Font("Ebrima", 10F);
            this.Hooked_Text_Label.ForeColor = System.Drawing.Color.Silver;
            this.Hooked_Text_Label.Location = new System.Drawing.Point(185, 49);
            this.Hooked_Text_Label.Name = "Hooked_Text_Label";
            this.Hooked_Text_Label.Size = new System.Drawing.Size(86, 19);
            this.Hooked_Text_Label.TabIndex = 20;
            this.Hooked_Text_Label.Text = "Hooked Text";
            // 
            // CountStageCB
            // 
            this.CountStageCB.AutoSize = true;
            this.CountStageCB.Font = new System.Drawing.Font("Ebrima", 10F);
            this.CountStageCB.ForeColor = System.Drawing.Color.Silver;
            this.CountStageCB.Location = new System.Drawing.Point(13, 156);
            this.CountStageCB.Name = "CountStageCB";
            this.CountStageCB.Size = new System.Drawing.Size(147, 23);
            this.CountStageCB.TabIndex = 21;
            this.CountStageCB.Text = "Count Hook Stages";
            this.CountStageCB.UseVisualStyleBackColor = true;
            this.CountStageCB.CheckedChanged += new System.EventHandler(this.CountStageCB_CheckedChanged);
            // 
            // Hook_Counter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(475, 407);
            this.Controls.Add(this.CountStageCB);
            this.Controls.Add(this.Hooked_Text_Label);
            this.Controls.Add(this.HookTextBox);
            this.Controls.Add(this.FontSizeLabel);
            this.Controls.Add(this.FontLabel);
            this.Controls.Add(this.LowerThreshCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IGUIScale);
            this.Controls.Add(this.UIScale);
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
        private System.Windows.Forms.ComboBox UIScale;
        private System.Windows.Forms.ComboBox IGUIScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox LowerThreshCheckbox;
        private System.Windows.Forms.Button ChangeFont;
        private System.Windows.Forms.Label FontSizeLabel;
        private System.Windows.Forms.Label FontLabel;
        private System.Windows.Forms.TextBox HookTextBox;
        private System.Windows.Forms.Label Hooked_Text_Label;
        private System.Windows.Forms.CheckBox CountStageCB;
    }
}