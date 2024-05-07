using System.Diagnostics;

namespace Trivia_Frontend_AvivRoss
{
    public partial class LoginPage : MainUserControl
    {
        public LoginPage(SoundManager soundManager, Panel panel) : base(soundManager, panel)
        {
            InitializeComponent();
        }

        public LoginPage(MainUserControl lastControl) : base(lastControl)
        {
            InitializeComponent();
        }


        // login button
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button pressed.");
            string username, password;
            username = TXTusername.Text;
            password = TXTpassword.Text;
            MSGmessage.Text = "";
            if (_requestHandler.Login(username, password))
            {
                Console.WriteLine("Login successful.");

                _requestHandler.SetStatus(Constants.MainMenu);

                MainMenu mainMenu = new MainMenu(username, this);


                _mainPanel.Controls.Remove(this);
                _mainPanel.Controls.Add(mainMenu);

            }
            else
            {
                Console.WriteLine("Login failed.");
                MSGmessage.Text = "Username or password incorrect.";
            }


        }

        // register button
        private void button1_Click_1(object sender, EventArgs e)
        {
            RegisterPage register = new RegisterPage(this);


            _mainPanel.Controls.Remove(this);
            _mainPanel.Controls.Add(register);

        }


        // show password
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TXTpassword.UseSystemPasswordChar = !TXTpassword.UseSystemPasswordChar;
        }

        // check when key pressed
        private void TXTusername_TextChanged(object sender, EventArgs e)
        {
            this.TXTusername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
        }

        // check for enter
        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                button1_Click(sender, e);
            }
        }
        // check when key pressed
        private void TXTpassword_TextChanged(object sender, EventArgs e)
        {
            this.TXTpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
        }

    }
}