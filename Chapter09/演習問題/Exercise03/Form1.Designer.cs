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
            components = new System.ComponentModel.Container();
            btStart = new Button();
            btStop = new Button();
            lbTimeDisp = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btReset = new Button();
            listBox1 = new ListBox();
            button1 = new Button();
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
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // btReset
            // 
            btReset.Location = new Point(37, 140);
            btReset.Name = "btReset";
            btReset.Size = new Size(163, 50);
            btReset.TabIndex = 0;
            btReset.Text = "リセット";
            btReset.UseVisualStyleBackColor = true;
            btReset.Click += btReset_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(404, 75);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(146, 109);
            listBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(217, 140);
            button1.Name = "button1";
            button1.Size = new Size(163, 50);
            button1.TabIndex = 0;
            button1.Text = "ラップタイム";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(604, 308);
            Controls.Add(listBox1);
            Controls.Add(lbTimeDisp);
            Controls.Add(button1);
            Controls.Add(btStop);
            Controls.Add(btReset);
            Controls.Add(btStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btStart;
        private Button btStop;
        private Label lbTimeDisp;
        private System.Windows.Forms.Timer timer1;
        private Button btReset;
        private ListBox listBox1;
        private Button button1;
    }
}
