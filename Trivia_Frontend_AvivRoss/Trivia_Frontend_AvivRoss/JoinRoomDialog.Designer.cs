namespace Trivia_Frontend_AvivRoss
{
    partial class JoinRoomDialog
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
            label1 = new Label();
            NUMroomId = new NumericUpDown();
            BTNok = new Button();
            ((System.ComponentModel.ISupportInitialize)NUMroomId).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(81, 9);
            label1.Name = "label1";
            label1.Size = new Size(112, 21);
            label1.TabIndex = 0;
            label1.Text = "Enter Room Id:";
            // 
            // NUMroomId
            // 
            NUMroomId.Location = new Point(108, 48);
            NUMroomId.Name = "NUMroomId";
            NUMroomId.Size = new Size(56, 23);
            NUMroomId.TabIndex = 1;
            // 
            // BTNok
            // 
            BTNok.BackColor = SystemColors.ActiveCaption;
            BTNok.Location = new Point(98, 77);
            BTNok.Name = "BTNok";
            BTNok.Size = new Size(75, 23);
            BTNok.TabIndex = 2;
            BTNok.Text = "Join";
            BTNok.UseVisualStyleBackColor = false;
            BTNok.Click += BTNok_Click;
            // 
            // JoinRoomDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 112);
            Controls.Add(BTNok);
            Controls.Add(NUMroomId);
            Controls.Add(label1);
            Name = "JoinRoomDialog";
            Text = "JoinRoomDialog";
            ((System.ComponentModel.ISupportInitialize)NUMroomId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown NUMroomId;
        private Button BTNok;
    }
}