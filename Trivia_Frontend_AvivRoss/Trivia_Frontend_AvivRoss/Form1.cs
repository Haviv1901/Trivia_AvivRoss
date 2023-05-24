using System.Diagnostics;

namespace Trivia_Frontend_AvivRoss
{
    public partial class Form1 : Form
    {
        private TriviaRequests _requestHandler;
        public Form1()
        {
            _requestHandler = new TriviaRequests();
            if (!_requestHandler.IsConnected())
                MessageBox.Show("failed to connec to server.");

            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button pressed.");
            string username, password;
            username = TXTusername.Text;
            password = TXTpassword.Text;
            if (_requestHandler.Login(username, password))
            {
                Console.WriteLine("Login successful.");
                MessageBox.Show("Login successful.");
            }
            else
            {
                Console.WriteLine("Login failed.");
                MessageBox.Show("Username or password incorrect.");
            }

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm(this);
            this.Hide();
            register.Show();
        }
    }
}