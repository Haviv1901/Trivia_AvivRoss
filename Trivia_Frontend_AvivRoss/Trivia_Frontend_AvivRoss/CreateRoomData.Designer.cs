namespace Trivia_Frontend_AvivRoss
{
    partial class CreateRoomData
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
            TXTroomName = new TextBox();
            NUMmaxPlayers = new NumericUpDown();
            NUManswerTimeOut = new NumericUpDown();
            NUMquestuinCount = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label = new Label();
            BTNok = new Button();
            button2 = new Button();
            TXTmsg = new Label();
            ((System.ComponentModel.ISupportInitialize)NUMmaxPlayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUManswerTimeOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUMquestuinCount).BeginInit();
            SuspendLayout();
            // 
            // TXTroomName
            // 
            TXTroomName.Location = new Point(12, 42);
            TXTroomName.Name = "TXTroomName";
            TXTroomName.Size = new Size(120, 23);
            TXTroomName.TabIndex = 0;
            TXTroomName.TextChanged += TXTroomName_TextChanged;
            // 
            // NUMmaxPlayers
            // 
            NUMmaxPlayers.Location = new Point(138, 42);
            NUMmaxPlayers.Name = "NUMmaxPlayers";
            NUMmaxPlayers.Size = new Size(120, 23);
            NUMmaxPlayers.TabIndex = 1;
            // 
            // NUManswerTimeOut
            // 
            NUManswerTimeOut.ForeColor = SystemColors.WindowFrame;
            NUManswerTimeOut.Location = new Point(138, 103);
            NUManswerTimeOut.Name = "NUManswerTimeOut";
            NUManswerTimeOut.Size = new Size(120, 23);
            NUManswerTimeOut.TabIndex = 2;
            // 
            // NUMquestuinCount
            // 
            NUMquestuinCount.Location = new Point(12, 103);
            NUMquestuinCount.Name = "NUMquestuinCount";
            NUMquestuinCount.Size = new Size(120, 23);
            NUMquestuinCount.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientActiveCaption;
            label1.Location = new Point(138, 24);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 4;
            label1.Text = "Max Players:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.GradientActiveCaption;
            label2.Location = new Point(12, 24);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 5;
            label2.Text = "Room Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.GradientActiveCaption;
            label3.Location = new Point(138, 85);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 6;
            label3.Text = "Answer Time Out:";
            // 
            // label
            // 
            label.AutoSize = true;
            label.BackColor = SystemColors.GradientActiveCaption;
            label.Location = new Point(12, 85);
            label.Name = "label";
            label.Size = new Size(94, 15);
            label.TabIndex = 7;
            label.Text = "Question Count:";
            // 
            // BTNok
            // 
            BTNok.BackColor = Color.Bisque;
            BTNok.Location = new Point(86, 176);
            BTNok.Name = "BTNok";
            BTNok.Size = new Size(75, 23);
            BTNok.TabIndex = 8;
            BTNok.Text = "Ok";
            BTNok.UseVisualStyleBackColor = false;
            BTNok.Click += BTNok_Click;
            // 
            // button2
            // 
            button2.Location = new Point(280, 98);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // TXTmsg
            // 
            TXTmsg.AutoSize = true;
            TXTmsg.ForeColor = Color.Red;
            TXTmsg.Location = new Point(80, 147);
            TXTmsg.Name = "TXTmsg";
            TXTmsg.Size = new Size(0, 15);
            TXTmsg.TabIndex = 10;
            // 
            // CreateRoomData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 211);
            Controls.Add(TXTmsg);
            Controls.Add(button2);
            Controls.Add(BTNok);
            Controls.Add(label);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NUMquestuinCount);
            Controls.Add(NUManswerTimeOut);
            Controls.Add(NUMmaxPlayers);
            Controls.Add(TXTroomName);
            Name = "CreateRoomData";
            Text = "CreateRoomData";
            FormClosed += CreateRoom_FormClosed;
            ((System.ComponentModel.ISupportInitialize)NUMmaxPlayers).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUManswerTimeOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUMquestuinCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TXTroomName;
        private NumericUpDown NUMmaxPlayers;
        private NumericUpDown NUManswerTimeOut;
        private NumericUpDown NUMquestuinCount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label;
        private Button BTNok;
        private Button button2;
        private Label TXTmsg;
    }
}