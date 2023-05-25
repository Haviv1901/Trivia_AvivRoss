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
            BTNsound = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 50F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(266, 43);
            label1.Name = "label1";
            label1.Size = new Size(188, 89);
            label1.TabIndex = 0;
            label1.Text = "Trivia";
            // 
            // BTNsound
            // 
            BTNsound.BackColor = Color.IndianRed;
            BTNsound.Location = new Point(0, 0);
            BTNsound.Name = "BTNsound";
            BTNsound.Size = new Size(28, 26);
            BTNsound.TabIndex = 1;
            BTNsound.Text = "🔇";
            BTNsound.UseVisualStyleBackColor = false;
            BTNsound.Click += BTNsound_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Khaki;
            button1.Location = new Point(279, 179);
            button1.Name = "button1";
            button1.Size = new Size(155, 35);
            button1.TabIndex = 2;
            button1.Text = "Join Room";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(BTNsound);
            Controls.Add(label1);
            Name = "MainMenu";
            Text = "MainMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BTNsound;
        private Button button1;
    }
}