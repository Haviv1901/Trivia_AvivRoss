namespace Trivia_Frontend_AvivRoss
{
    partial class GameResultScreen
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
            TXTscores = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Snap ITC", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkBlue;
            label1.Location = new Point(268, 44);
            label1.Name = "label1";
            label1.Size = new Size(236, 35);
            label1.TabIndex = 9;
            label1.Text = "Game Results:";
            label1.Click += label1_Click;
            // 
            // TXTscores
            // 
            TXTscores.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TXTscores.Location = new Point(268, 110);
            TXTscores.Name = "TXTscores";
            TXTscores.Size = new Size(236, 311);
            TXTscores.TabIndex = 10;
            TXTscores.Text = "users - score";
            TXTscores.TextAlign = ContentAlignment.TopCenter;
            // 
            // GameResultScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TXTscores);
            Controls.Add(label1);
            Name = "GameResultScreen";
            Load += GameResultScreen_Load;
            Controls.SetChildIndex(BTNsound, 0);
            Controls.SetChildIndex(BTNexit, 0);
            Controls.SetChildIndex(BTNback, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(TXTscores, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label TXTscores;
    }
}
