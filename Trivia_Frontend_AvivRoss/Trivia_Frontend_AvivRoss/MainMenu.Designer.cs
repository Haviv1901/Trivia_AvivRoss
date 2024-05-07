namespace Trivia_Frontend_AvivRoss
{
    partial class MainMenu
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
            label1 = new Label();
            BTNjoinRoom = new Button();
            BTNcreateRoom = new Button();
            BTNstats = new Button();
            TXTwelcome = new Label();

            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 50F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(305, 43);
            label1.Name = "label1";
            label1.Size = new Size(188, 89);
            label1.TabIndex = 0;
            label1.Text = "Trivia";
            // 
            // BTNjoinRoom
            // 
            BTNjoinRoom.BackColor = Color.Khaki;
            BTNjoinRoom.Location = new Point(325, 180);
            BTNjoinRoom.Name = "BTNjoinRoom";
            BTNjoinRoom.Size = new Size(155, 35);
            BTNjoinRoom.TabIndex = 2;
            BTNjoinRoom.Text = "Join Room";
            BTNjoinRoom.UseVisualStyleBackColor = false;
            BTNjoinRoom.Click += button1_Click;
            // 
            // BTNcreateRoom
            // 
            BTNcreateRoom.BackColor = Color.Khaki;
            BTNcreateRoom.Location = new Point(325, 235);
            BTNcreateRoom.Name = "BTNcreateRoom";
            BTNcreateRoom.Size = new Size(155, 35);
            BTNcreateRoom.TabIndex = 3;
            BTNcreateRoom.Text = "Create Room";
            BTNcreateRoom.UseVisualStyleBackColor = false;
            BTNcreateRoom.Click += button2_Click;
            // 
            // BTNstats
            // 
            BTNstats.BackColor = Color.Khaki;
            BTNstats.Location = new Point(325, 290);
            BTNstats.Name = "BTNstats";
            BTNstats.Size = new Size(155, 35);
            BTNstats.TabIndex = 4;
            BTNstats.Text = "Stats";
            BTNstats.UseVisualStyleBackColor = false;
            BTNstats.Click += button3_Click;
            // 
            // TXTwelcome
            // 
            TXTwelcome.AutoSize = true;
            TXTwelcome.Location = new Point(348, 117);
            TXTwelcome.Name = "TXTwelcome";
            TXTwelcome.Size = new Size(90, 15);
            TXTwelcome.TabIndex = 6;
            TXTwelcome.Text = "Welcome Guest";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            Controls.Add(TXTwelcome);
            Controls.Add(BTNstats);
            Controls.Add(BTNcreateRoom);
            Controls.Add(BTNjoinRoom);
            Controls.Add(label1);
            Name = "MainMenu";
            Size = new Size(800, 450);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(BTNjoinRoom, 0);
            Controls.SetChildIndex(BTNcreateRoom, 0);
            Controls.SetChildIndex(BTNstats, 0);
            Controls.SetChildIndex(TXTwelcome, 0);

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;

        private Button BTNjoinRoom;
        private Button BTNcreateRoom;
        private Button BTNstats;
        private Label TXTwelcome;
    }
}