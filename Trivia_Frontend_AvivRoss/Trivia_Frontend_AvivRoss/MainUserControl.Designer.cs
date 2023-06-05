namespace Trivia_Frontend_AvivRoss
{
    partial class MainUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BTNsound = new Button();
            Back = new Button();
            SuspendLayout();
            // 
            // BTNsound
            // 
            BTNsound.BackColor = Color.IndianRed;
            BTNsound.FlatStyle = FlatStyle.Popup;
            BTNsound.Location = new Point(0, 0);
            BTNsound.Name = "BTNsound";
            BTNsound.Size = new Size(28, 26);
            BTNsound.TabIndex = 1;
            BTNsound.Text = "🔇";
            BTNsound.UseVisualStyleBackColor = false;
            BTNsound.Click += BTNsound_Click;
            // 
            // Back
            // 
            Back.BackColor = Color.Red;
            Back.FlatStyle = FlatStyle.Popup;
            Back.Location = new Point(744, 2);
            Back.Name = "Back";
            Back.Size = new Size(69, 24);
            Back.TabIndex = 2;
            Back.Text = "button1";
            Back.UseVisualStyleBackColor = false;
            Back.Click += Back_Click;
            // 
            // MainUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Back);
            Controls.Add(BTNsound);
            Name = "MainUserControl";
            Size = new Size(816, 489);
            ResumeLayout(false);
        }

        #endregion

        private Button BTNsound;
        private Button Back;
    }
}
