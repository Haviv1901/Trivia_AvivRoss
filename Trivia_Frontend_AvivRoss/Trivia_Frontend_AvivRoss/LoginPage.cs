using System.Diagnostics;

namespace Trivia_Frontend_AvivRoss
{
    public partial class LoginPage : MainUserControl
    {

        public LoginPage(SoundManager soundManager) : base(soundManager)
        {
            InitializeComponent();
        }



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

                MainMenuUtis mainMenuUtis = new MainMenuUtis(username);
                MainMenu mainMenu = new MainMenu(mainMenuUtis, this);

                mainMenu.Show();
                this.Hide();

            }
            else
            {
                Console.WriteLine("Login failed.");
                MSGmessage.Text = "Username or password incorrect.";
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegisterPage register = new RegisterPage(soundManager, this);
            Controls.Clear();
            Controls.Add(register);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _requestHandler.Disconnect();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TXTpassword.UseSystemPasswordChar = !TXTpassword.UseSystemPasswordChar;
        }

        private void TXTusername_TextChanged(object sender, EventArgs e)
        {
            this.TXTusername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                button1_Click(sender, e);
            }
        }

        private void TXTpassword_TextChanged(object sender, EventArgs e)
        {
            this.TXTpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}