namespace Trivia_Frontend_AvivRoss
{
    partial class RegisterForm
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
            INusername = new TextBox();
            INemail = new TextBox();
            INpass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            INpass2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            TXTmsg = new Label();
            BTNregister = new Button();
            BOXconfirm = new CheckBox();
            button1 = new Button();
            CHKshowPass = new CheckBox();
            SuspendLayout();
            // 
            // INusername
            // 
            INusername.Location = new Point(247, 125);
            INusername.Name = "INusername";
            INusername.Size = new Size(273, 23);
            INusername.TabIndex = 0;
            // 
            // INemail
            // 
            INemail.Location = new Point(247, 178);
            INemail.Name = "INemail";
            INemail.Size = new Size(273, 23);
            INemail.TabIndex = 1;
            // 
            // INpass
            // 
            INpass.Location = new Point(248, 233);
            INpass.Name = "INpass";
            INpass.Size = new Size(273, 23);
            INpass.TabIndex = 2;
            INpass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(247, 107);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(320, 48);
            label2.Name = "label2";
            label2.Size = new Size(82, 28);
            label2.Text = "Register";
            // 
            // INpass2
            // 
            INpass2.Location = new Point(247, 275);
            INpass2.Name = "INpass2";
            INpass2.Size = new Size(273, 23);
            INpass2.TabIndex = 3;
            INpass2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(247, 160);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(247, 215);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(248, 259);
            label5.Name = "label5";
            label5.Size = new Size(104, 15);
            label5.Text = "Confirm Password";
            // 
            // TXTmsg
            // 
            TXTmsg.AutoSize = true;
            TXTmsg.ForeColor = Color.OrangeRed;
            TXTmsg.Location = new Point(320, 372);
            TXTmsg.Name = "TXTmsg";
            TXTmsg.Size = new Size(0, 15);
            // 
            // BTNregister
            // 
            BTNregister.BackColor = SystemColors.ActiveCaption;
            BTNregister.Location = new Point(320, 354);
            BTNregister.Name = "BTNregister";
            BTNregister.Size = new Size(75, 23);
            BTNregister.TabIndex = 5;
            BTNregister.Text = "Register";
            BTNregister.UseVisualStyleBackColor = false;
            BTNregister.Click += BTNregister_Click;
            // 
            // BOXconfirm
            // 
            BOXconfirm.AutoSize = true;
            BOXconfirm.Location = new Point(248, 329);
            BOXconfirm.Name = "BOXconfirm";
            BOXconfirm.Size = new Size(165, 19);
            BOXconfirm.TabIndex = 4;
            BOXconfirm.Text = "Confirm me hacking ur pc";
            BOXconfirm.UseVisualStyleBackColor = true;
            BOXconfirm.CheckedChanged += BOXconfirm_CheckedChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 255, 128);
            button1.Location = new Point(216, 415);
            button1.Name = "button1";
            button1.Size = new Size(329, 23);
            button1.TabIndex = 12;
            button1.Text = "Actually  I do have a user get me out of this window";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // CHKshowPass
            // 
            CHKshowPass.AutoSize = true;
            CHKshowPass.Location = new Point(248, 304);
            CHKshowPass.Name = "CHKshowPass";
            CHKshowPass.Size = new Size(108, 19);
            CHKshowPass.TabIndex = 13;
            CHKshowPass.Text = "Show password";
            CHKshowPass.UseVisualStyleBackColor = true;
            CHKshowPass.CheckedChanged += CHKshowPass_CheckedChanged;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CHKshowPass);
            Controls.Add(button1);
            Controls.Add(BOXconfirm);
            Controls.Add(BTNregister);
            Controls.Add(TXTmsg);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(INpass2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(INpass);
            Controls.Add(INemail);
            Controls.Add(INusername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegisterForm";
            Text = "RegisterForm";
            FormClosed += RegisterForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox INusername;
        private TextBox INemail;
        private TextBox INpass;
        private Label label1;
        private Label label2;
        private TextBox INpass2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label TXTmsg;
        private Button BTNregister;
        private CheckBox BOXconfirm;
        private Button button1;
        private CheckBox CHKshowPass;
    }
}