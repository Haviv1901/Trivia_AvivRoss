namespace Trivia_Frontend_AvivRoss
{
    partial class RoomBrowser
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
            NUMroomId = new NumericUpDown();
            FLWroomsListScorll = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            BTNjoinButton = new Button();
            ((System.ComponentModel.ISupportInitialize)NUMroomId).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(322, 37);
            label1.Name = "label1";
            label1.Size = new Size(72, 28);
            label1.TabIndex = 0;
            label1.Text = "Rooms";
            label1.Click += label1_Click;
            // 
            // NUMroomId
            // 
            NUMroomId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            NUMroomId.Location = new Point(289, 68);
            NUMroomId.Name = "NUMroomId";
            NUMroomId.Size = new Size(142, 23);
            NUMroomId.TabIndex = 1;
            // 
            // FLWroomsListScorll
            // 
            FLWroomsListScorll.Location = new Point(189, 127);
            FLWroomsListScorll.Name = "FLWroomsListScorll";
            FLWroomsListScorll.Size = new Size(385, 331);
            FLWroomsListScorll.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Location = new Point(319, 98);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Location = new Point(723, 1);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // BTNjoinButton
            // 
            BTNjoinButton.BackColor = Color.YellowGreen;
            BTNjoinButton.Location = new Point(437, 68);
            BTNjoinButton.Name = "BTNjoinButton";
            BTNjoinButton.Size = new Size(37, 23);
            BTNjoinButton.TabIndex = 5;
            BTNjoinButton.Text = "Join";
            BTNjoinButton.UseVisualStyleBackColor = false;
            BTNjoinButton.Click += BTNjoinButton_Click;
            // 
            // RoomBrowser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BTNjoinButton);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(FLWroomsListScorll);
            Controls.Add(NUMroomId);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RoomBrowser";
            Text = "RoomBrowser";
            FormClosed += RoomBrowser_FormClosed;
            ((System.ComponentModel.ISupportInitialize)NUMroomId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown NUMroomId;
        private FlowLayoutPanel FLWroomsListScorll;
        private Button button1;
        private Button button2;
        private Button BTNjoinButton;
    }
}