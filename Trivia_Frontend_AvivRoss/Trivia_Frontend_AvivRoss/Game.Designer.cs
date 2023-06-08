namespace Trivia_Frontend_AvivRoss
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            BTNanswer4 = new Button();
            BTNanswer3 = new Button();
            BTNanswer2 = new Button();
            BTNanswer1 = new Button();
            TXTquestion = new Label();
            TMRtimeBetweenEachQuestion = new System.Windows.Forms.Timer(components);
            TMRquestionTimer = new System.Windows.Forms.Timer(components);
            TXTtimeLeft = new Label();
            TXTquestionLeft = new Label();
            SuspendLayout();
            // 
            // BTNanswer4
            // 
            BTNanswer4.BackColor = Color.SkyBlue;
            BTNanswer4.FlatStyle = FlatStyle.Popup;
            BTNanswer4.Location = new Point(515, 251);
            BTNanswer4.Name = "BTNanswer4";
            BTNanswer4.Size = new Size(187, 48);
            BTNanswer4.TabIndex = 0;
            BTNanswer4.Tag = "4";
            BTNanswer4.Text = "button1";
            BTNanswer4.UseVisualStyleBackColor = false;
            BTNanswer4.Click += BTNanswer4_Click;
            // 
            // BTNanswer3
            // 
            BTNanswer3.BackColor = Color.SkyBlue;
            BTNanswer3.FlatStyle = FlatStyle.Popup;
            BTNanswer3.Location = new Point(515, 142);
            BTNanswer3.Name = "BTNanswer3";
            BTNanswer3.Size = new Size(187, 48);
            BTNanswer3.TabIndex = 1;
            BTNanswer3.Tag = "3";
            BTNanswer3.Text = "button2";
            BTNanswer3.UseVisualStyleBackColor = false;
            BTNanswer3.Click += BTNanswer3_Click;
            // 
            // BTNanswer2
            // 
            BTNanswer2.BackColor = Color.SkyBlue;
            BTNanswer2.FlatStyle = FlatStyle.Popup;
            BTNanswer2.Location = new Point(119, 251);
            BTNanswer2.Name = "BTNanswer2";
            BTNanswer2.Size = new Size(187, 48);
            BTNanswer2.TabIndex = 2;
            BTNanswer2.Tag = "2";
            BTNanswer2.Text = "button3";
            BTNanswer2.UseVisualStyleBackColor = false;
            BTNanswer2.Click += BTNanswer2_Click;
            // 
            // BTNanswer1
            // 
            BTNanswer1.BackColor = Color.SkyBlue;
            BTNanswer1.FlatStyle = FlatStyle.Popup;
            BTNanswer1.Location = new Point(119, 142);
            BTNanswer1.Name = "BTNanswer1";
            BTNanswer1.Size = new Size(187, 48);
            BTNanswer1.TabIndex = 3;
            BTNanswer1.Tag = "1";
            BTNanswer1.Text = "button4";
            BTNanswer1.UseVisualStyleBackColor = false;
            BTNanswer1.Click += BTNanswer1_Click;
            // 
            // TXTquestion
            // 
            TXTquestion.BackColor = Color.Transparent;
            TXTquestion.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            TXTquestion.Location = new Point(1, 9);
            TXTquestion.Name = "TXTquestion";
            TXTquestion.Size = new Size(799, 78);
            TXTquestion.TabIndex = 4;
            TXTquestion.Text = "Question";
            TXTquestion.TextAlign = ContentAlignment.TopCenter;
            TXTquestion.Click += TXTquestion_Click;
            // 
            // TMRtimeBetweenEachQuestion
            // 
            TMRtimeBetweenEachQuestion.Tick += TMRtimeBetweenEachQuestion_Tick;
            // 
            // TMRquestionTimer
            // 
            TMRquestionTimer.Interval = 1000;
            TMRquestionTimer.Tick += TMRquestionTimer_Tick_1;
            // 
            // TXTtimeLeft
            // 
            TXTtimeLeft.AutoSize = true;
            TXTtimeLeft.Font = new Font("Vladimir Script", 25F, FontStyle.Regular, GraphicsUnit.Point);
            TXTtimeLeft.Location = new Point(394, 204);
            TXTtimeLeft.Name = "TXTtimeLeft";
            TXTtimeLeft.Size = new Size(34, 42);
            TXTtimeLeft.TabIndex = 5;
            TXTtimeLeft.Text = "9";
            // 
            // TXTquestionLeft
            // 
            TXTquestionLeft.AutoSize = true;
            TXTquestionLeft.Location = new Point(758, 87);
            TXTquestionLeft.Name = "TXTquestionLeft";
            TXTquestionLeft.Size = new Size(30, 15);
            TXTquestionLeft.TabIndex = 6;
            TXTquestionLeft.Text = "5/10";
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TXTquestionLeft);
            Controls.Add(TXTtimeLeft);
            Controls.Add(TXTquestion);
            Controls.Add(BTNanswer1);
            Controls.Add(BTNanswer2);
            Controls.Add(BTNanswer3);
            Controls.Add(BTNanswer4);
            Name = "Game";
            Text = "Trivia";
            Load += Game_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTNanswer4;
        private Button BTNanswer3;
        private Button BTNanswer2;
        private Button BTNanswer1;
        private Label TXTquestion;
        private System.Windows.Forms.Timer TMRtimeBetweenEachQuestion;
        private System.Windows.Forms.Timer TMRquestionTimer;
        private Label TXTtimeLeft;
        private Label TXTquestionLeft;
    }
}