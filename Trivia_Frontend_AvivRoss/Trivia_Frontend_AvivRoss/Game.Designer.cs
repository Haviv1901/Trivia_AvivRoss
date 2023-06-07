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
            BTNanswer4 = new Button();
            BTNanswer3 = new Button();
            BTNanswer2 = new Button();
            BTNanswer1 = new Button();
            TXTquestion = new Label();
            SuspendLayout();
            // 
            // BTNanswer4
            // 
            BTNanswer4.BackColor = Color.SkyBlue;
            BTNanswer4.FlatStyle = FlatStyle.Popup;
            BTNanswer4.Location = new Point(389, 234);
            BTNanswer4.Name = "BTNanswer4";
            BTNanswer4.Size = new Size(187, 48);
            BTNanswer4.TabIndex = 0;
            BTNanswer4.Text = "button1";
            BTNanswer4.UseVisualStyleBackColor = false;
            // 
            // BTNanswer3
            // 
            BTNanswer3.BackColor = Color.SkyBlue;
            BTNanswer3.FlatStyle = FlatStyle.Popup;
            BTNanswer3.Location = new Point(389, 159);
            BTNanswer3.Name = "BTNanswer3";
            BTNanswer3.Size = new Size(187, 48);
            BTNanswer3.TabIndex = 1;
            BTNanswer3.Text = "button2";
            BTNanswer3.UseVisualStyleBackColor = false;
            // 
            // BTNanswer2
            // 
            BTNanswer2.BackColor = Color.SkyBlue;
            BTNanswer2.FlatStyle = FlatStyle.Popup;
            BTNanswer2.Location = new Point(115, 234);
            BTNanswer2.Name = "BTNanswer2";
            BTNanswer2.Size = new Size(187, 48);
            BTNanswer2.TabIndex = 2;
            BTNanswer2.Text = "button3";
            BTNanswer2.UseVisualStyleBackColor = false;
            // 
            // BTNanswer1
            // 
            BTNanswer1.BackColor = Color.SkyBlue;
            BTNanswer1.FlatStyle = FlatStyle.Popup;
            BTNanswer1.Location = new Point(115, 159);
            BTNanswer1.Name = "BTNanswer1";
            BTNanswer1.Size = new Size(187, 48);
            BTNanswer1.TabIndex = 3;
            BTNanswer1.Text = "button4";
            BTNanswer1.UseVisualStyleBackColor = false;
            // 
            // TXTquestion
            // 
            TXTquestion.BackColor = Color.Transparent;
            TXTquestion.Location = new Point(314, 33);
            TXTquestion.Name = "TXTquestion";
            TXTquestion.Size = new Size(100, 23);
            TXTquestion.TabIndex = 4;
            TXTquestion.Text = "Question";
            TXTquestion.TextAlign = ContentAlignment.TopCenter;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TXTquestion);
            Controls.Add(BTNanswer1);
            Controls.Add(BTNanswer2);
            Controls.Add(BTNanswer3);
            Controls.Add(BTNanswer4);
            Name = "Game";
            Text = "Trivia";
            ResumeLayout(false);
        }

        #endregion

        private Button BTNanswer4;
        private Button BTNanswer3;
        private Button BTNanswer2;
        private Button BTNanswer1;
        private Label TXTquestion;
    }
}