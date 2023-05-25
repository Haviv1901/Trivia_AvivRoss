namespace Trivia_Frontend_AvivRoss
{
    partial class Room
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
            TXTroomId = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            TXTcreatorName = new Label();
            TXTanswerTimeOut = new Label();
            TXTnumOfQuestions = new Label();
            TXTmaxPlayers = new Label();
            TXTroomName = new Label();
            SuspendLayout();
            // 
            // TXTroomId
            // 
            TXTroomId.AutoSize = true;
            TXTroomId.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TXTroomId.Location = new Point(84, 65);
            TXTroomId.Name = "TXTroomId";
            TXTroomId.Size = new Size(68, 19);
            TXTroomId.TabIndex = 0;
            TXTroomId.Text = "Room Id: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 137);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 1;
            label2.Text = "Player number 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 152);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 2;
            label3.Text = "Player number 2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(84, 167);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 3;
            label4.Text = "Player number n";
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Location = new Point(724, -1);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // TXTcreatorName
            // 
            TXTcreatorName.AutoSize = true;
            TXTcreatorName.Location = new Point(272, 69);
            TXTcreatorName.Name = "TXTcreatorName";
            TXTcreatorName.Size = new Size(81, 15);
            TXTcreatorName.TabIndex = 5;
            TXTcreatorName.Text = "Creator Name";
            // 
            // TXTanswerTimeOut
            // 
            TXTanswerTimeOut.AutoSize = true;
            TXTanswerTimeOut.Location = new Point(272, 103);
            TXTanswerTimeOut.Name = "TXTanswerTimeOut";
            TXTanswerTimeOut.Size = new Size(104, 15);
            TXTanswerTimeOut.TabIndex = 6;
            TXTanswerTimeOut.Text = "Answer Time Out: ";
            // 
            // TXTnumOfQuestions
            // 
            TXTnumOfQuestions.AutoSize = true;
            TXTnumOfQuestions.Location = new Point(272, 137);
            TXTnumOfQuestions.Name = "TXTnumOfQuestions";
            TXTnumOfQuestions.Size = new Size(127, 15);
            TXTnumOfQuestions.TabIndex = 7;
            TXTnumOfQuestions.Text = "Number of Questions: ";
            // 
            // TXTmaxPlayers
            // 
            TXTmaxPlayers.AutoSize = true;
            TXTmaxPlayers.Location = new Point(272, 167);
            TXTmaxPlayers.Name = "TXTmaxPlayers";
            TXTmaxPlayers.Size = new Size(76, 15);
            TXTmaxPlayers.TabIndex = 8;
            TXTmaxPlayers.Text = "Max Players: ";
            // 
            // TXTroomName
            // 
            TXTroomName.AutoSize = true;
            TXTroomName.Location = new Point(214, 24);
            TXTroomName.Name = "TXTroomName";
            TXTroomName.Size = new Size(74, 15);
            TXTroomName.TabIndex = 9;
            TXTroomName.Text = "Room Name";
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TXTroomName);
            Controls.Add(TXTmaxPlayers);
            Controls.Add(TXTnumOfQuestions);
            Controls.Add(TXTanswerTimeOut);
            Controls.Add(TXTcreatorName);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TXTroomId);
            Name = "Room";
            Text = "Room";
            FormClosed += Room_FormClose;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TXTroomId;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Label TXTcreatorName;
        private Label TXTanswerTimeOut;
        private Label TXTnumOfQuestions;
        private Label TXTmaxPlayers;
        private Label TXTroomName;
    }
}