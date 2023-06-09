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
            BTNexit = new Button();
            BTNback = new Button();
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
            // BTNexit
            // 
            BTNexit.BackColor = Color.Red;
            BTNexit.FlatStyle = FlatStyle.Popup;
            BTNexit.Location = new Point(747, 29);
            BTNexit.Name = "BTNexit";
            BTNexit.Size = new Size(53, 24);
            BTNexit.TabIndex = 7;
            BTNexit.Text = "Exit";
            BTNexit.UseVisualStyleBackColor = false;
            BTNexit.Click += BTNexit_Click;
            // 
            // BTNback
            // 
            BTNback.BackColor = Color.Red;
            BTNback.FlatStyle = FlatStyle.Popup;
            BTNback.Location = new Point(741, 3);
            BTNback.Name = "BTNback";
            BTNback.Size = new Size(59, 23);
            BTNback.TabIndex = 8;
            BTNback.Text = "Back";
            BTNback.UseVisualStyleBackColor = false;
            BTNback.Click += BTNbackButtonClicked;
            // 
            // MainUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BTNback);
            Controls.Add(BTNexit);
            Controls.Add(BTNsound);
            Name = "MainUserControl";
            Size = new Size(816, 489);
            ResumeLayout(false);
        }

        #endregion

        protected Button BTNsound;
        protected Button BTNback;
        protected Button BTNexit;
    }
}
