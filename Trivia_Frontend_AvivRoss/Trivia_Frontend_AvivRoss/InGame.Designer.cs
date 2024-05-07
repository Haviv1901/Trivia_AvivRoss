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
            components = new System.ComponentModel.Container();
            TMRname = new System.Windows.Forms.Timer(components);
            BTNbackAfterGame = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // TMRname
            // 
            TMRname.Interval = 1000;
            TMRname.Tick += TMRname_Tick;
            // 
            // BTNbackAfterGame
            // 
            BTNbackAfterGame.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BTNbackAfterGame.BackColor = Color.Red;
            BTNbackAfterGame.FlatStyle = FlatStyle.Popup;
            BTNbackAfterGame.Location = new Point(306, 388);
            BTNbackAfterGame.Name = "BTNbackAfterGame";
            BTNbackAfterGame.Size = new Size(157, 23);
            BTNbackAfterGame.TabIndex = 10;
            BTNbackAfterGame.Text = "Back to main menu";
            BTNbackAfterGame.UseVisualStyleBackColor = false;
            BTNbackAfterGame.Click += BTNbackAfterGame_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Font = new Font("Viner Hand ITC", 50.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkSlateBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(816, 489);
            label1.TabIndex = 9;
            label1.Text = "Loading Game...";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Name = "InGame";
            Load += InGame_Load;
            Controls.SetChildIndex(BTNsound, 0);
            Controls.SetChildIndex(BTNexit, 0);
            Controls.SetChildIndex(BTNback, 0);
            Controls.SetChildIndex(label1, 0);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer TMRname;
        private Button BTNbackAfterGame;
        private Label label1;
    }
}
