namespace Trivia_Frontend_AvivRoss
{
    partial class InGame
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
            label1 = new Label();
            BTNbackAfterGame = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Viner Hand ITC", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkSlateBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(816, 489);
            label1.TabIndex = 9;
            label1.Text = "Loading Game...";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BTNbackAfterGame
            // 
            BTNbackAfterGame.BackColor = Color.Red;
            BTNbackAfterGame.Location = new Point(335, 381);
            BTNbackAfterGame.Name = "BTNbackAfterGame";
            BTNbackAfterGame.Size = new Size(75, 23);
            BTNbackAfterGame.TabIndex = 10;
            BTNbackAfterGame.Text = "Back to main menu";
            BTNbackAfterGame.UseVisualStyleBackColor = false;
            BTNbackAfterGame.Click += BTNbackAfterGame_Click;
            // 
            // InGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BTNbackAfterGame);
            Controls.Add(label1);
            Name = "InGame";
            Controls.SetChildIndex(BTNsound, 0);
            Controls.SetChildIndex(BTNexit, 0);
            Controls.SetChildIndex(BTNback, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(BTNbackAfterGame, 0);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button BTNbackAfterGame;
    }
}
