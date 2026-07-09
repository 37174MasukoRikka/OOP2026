namespace Exercise03 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btStart = new Button();
            btStop = new Button();
            lbTimeDisp = new Label();
            SuspendLayout();
            // 
            // btStart
            // 
            btStart.Location = new Point(37, 84);
            btStart.Name = "btStart";
            btStart.Size = new Size(163, 50);
            btStart.TabIndex = 0;
            btStart.Text = "スタート";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // btStop
            // 
            btStop.Location = new Point(217, 84);
            btStop.Name = "btStop";
            btStop.Size = new Size(163, 50);
            btStop.TabIndex = 0;
            btStop.Text = "ストップ";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += btStop_Click;
            // 
            // lbTimeDisp
            // 
            lbTimeDisp.BackColor = Color.FromArgb(192, 255, 192);
            lbTimeDisp.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTimeDisp.Location = new Point(37, 22);
            lbTimeDisp.Name = "lbTimeDisp";
            lbTimeDisp.Size = new Size(343, 40);
            lbTimeDisp.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(437, 163);
            Controls.Add(lbTimeDisp);
            Controls.Add(btStop);
            Controls.Add(btStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btStart;
        private Button btStop;
        private Label lbTimeDisp;
    }
}
