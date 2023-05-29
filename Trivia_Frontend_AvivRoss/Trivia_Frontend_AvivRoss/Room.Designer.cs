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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            button1 = new Button();
            TXTroomId = new Label();
            BTNrefresh = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Location = new Point(376, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // TXTroomId
            // 
            TXTroomId.AutoSize = true;
            TXTroomId.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            TXTroomId.ForeColor = Color.ForestGreen;
            TXTroomId.Location = new Point(171, 22);
            TXTroomId.Name = "TXTroomId";
            TXTroomId.Size = new Size(95, 28);
            TXTroomId.TabIndex = 10;
            TXTroomId.Text = "Room Id: ";
            // 
            // BTNrefresh
            // 
            BTNrefresh.BackColor = Color.Azure;
            BTNrefresh.Location = new Point(29, 77);
            BTNrefresh.Name = "BTNrefresh";
            BTNrefresh.Size = new Size(80, 20);
            BTNrefresh.TabIndex = 11;
            BTNrefresh.Text = "Refresh";
            BTNrefresh.UseVisualStyleBackColor = false;
            BTNrefresh.Click += BTNrefresh_Click;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 299);
            Controls.Add(BTNrefresh);
            Controls.Add(TXTroomId);
            Controls.Add(button1);
            Name = "Room";
            Text = "Room";
            FormClosed += Room_FormClose;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Label TXTroomId;
        private Button BTNrefresh;
    }
}