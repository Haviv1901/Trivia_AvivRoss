namespace Trivia_Frontend_AvivRoss
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FormClosed += Form1_FormClosed;

            components = new System.ComponentModel.Container();
            TXTpassword = new TextBox();
            BTNlogin = new Button();
            TXTusername = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            sdsdToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TXTpassword
            // 
            TXTpassword.AccessibleName = "TXTusername";
            TXTpassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TXTpassword.ForeColor = SystemColors.ActiveCaptionText;
            TXTpassword.Location = new Point(265, 196);
            TXTpassword.Name = "TXTpassword";
            TXTpassword.Size = new Size(254, 23);
            TXTpassword.TabIndex = 0;
            TXTpassword.TextChanged += textBox1_TextChanged;
            // 
            // BTNlogin
            // 
            BTNlogin.AccessibleName = "BTNloginPage";
            BTNlogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BTNlogin.BackColor = SystemColors.ActiveCaption;
            BTNlogin.Location = new Point(320, 274);
            BTNlogin.Name = "BTNlogin";
            BTNlogin.Size = new Size(130, 32);
            BTNlogin.TabIndex = 1;
            BTNlogin.Text = "Login";
            BTNlogin.UseVisualStyleBackColor = false;
            BTNlogin.Click += button1_Click;
            // 
            // TXTusername
            // 
            TXTusername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TXTusername.Location = new Point(265, 141);
            TXTusername.Name = "TXTusername";
            TXTusername.Size = new Size(255, 23);
            TXTusername.TabIndex = 2;
            TXTusername.TextChanged += textBox2_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { sdsdToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(99, 26);
            // 
            // sdsdToolStripMenuItem
            // 
            sdsdToolStripMenuItem.Name = "sdsdToolStripMenuItem";
            sdsdToolStripMenuItem.Size = new Size(98, 22);
            sdsdToolStripMenuItem.Text = "sdsd";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(178, 46);
            label1.Name = "label1";
            label1.Size = new Size(438, 66);
            label1.TabIndex = 3;
            label1.Text = "Welcome to the trivia game!";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 123);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 5;
            label3.Text = "Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(268, 178);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 6;
            label4.Text = "Password";
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Location = new Point(219, 312);
            button1.Name = "button1";
            button1.Size = new Size(383, 30);
            button1.TabIndex = 7;
            button1.Text = "Dont have a user? what r u doing PRESS ME!!!!!";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 436);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(TXTusername);
            Controls.Add(BTNlogin);
            Controls.Add(TXTpassword);
            Name = "Form1";
            Text = "Form1";
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TXTpassword;
        private Button BTNlogin;
        private TextBox TXTusername;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem sdsdToolStripMenuItem;
        private Label label1;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}