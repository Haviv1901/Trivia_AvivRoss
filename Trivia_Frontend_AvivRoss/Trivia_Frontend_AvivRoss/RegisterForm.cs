using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trivia_Frontend_AvivRoss
{
    public partial class RegisterForm : Form
    {
        private Form1 _loginForm;
        public RegisterForm(Form1 loginForm)
        {
            _loginForm = loginForm;
            InitializeComponent();
        }

        private void BTNregister_Click(object sender, EventArgs e)
        {
            string username = INusername.Text, password = INpass.Text, password2 = INpass2.Text, email = INemail.Text;
            bool checkBox = BOXconfirm.Checked;

            if (password != password2)
            {
                TXTmsg.Text = "Passwords do not match.";
                return;
            }
            if (!checkBox)
            {
                TXTmsg.Text = "Please confirm the terms and conditions.";
                return;
            }


            if (TriviaRequests.instance.Register(username, password, email))
            {
                Console.WriteLine("Sign In successfuly.");
                MessageBox.Show("Sign In successfuly.");
                
                TriviaRequests.instance.SetStatus(Constants.MainMenu);

                MainMenuUtis mainMenuUtis = new MainMenuUtis(username);
                MainMenu mainMenu = new MainMenu(mainMenuUtis, _loginForm);


                mainMenu.Show();
                this.Close();
            }
            else
            {
                Console.WriteLine("Sign In failed.");
                MessageBox.Show("failed to sign in. make sure u have a steady connection and email and password correct.");
            }
        }

        private void BOXconfirm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _loginForm.Show();
            this.Close();
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TriviaRequests.instance.Disconnect();
        }
    }
}
