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
            BTNrefresh = new Button();
            button2 = new Button();
            SuspendLayout();
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
            // button2
            // 
            button2.BackColor = Color.LemonChiffon;
            button2.Location = new Point(298, 207);
            button2.Name = "button2";
            button2.Size = new Size(118, 38);
            button2.TabIndex = 12;
            button2.Text = "Start Game";
            button2.UseVisualStyleBackColor = false;
            button2.Click += StartGame_buttonClick;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BTNrefresh);
            Controls.Add(TXTroomId);
            Name = "Room";
            Text = "Room";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label TXTroomId;
        private Button BTNrefresh;
        private Button button2;
    }
}