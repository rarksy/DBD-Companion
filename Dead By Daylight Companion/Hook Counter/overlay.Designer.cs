namespace Dead_By_Daylight_Companion.Hook_Counter {
    partial class overlay {
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
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // DrawTimer
            // 
            this.DrawTimer.Interval = 1000;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(211, 581);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "overlay";
            this.Text = "overlay";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.overlay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer DrawTimer;
    }
}