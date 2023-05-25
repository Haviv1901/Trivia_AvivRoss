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
    public partial class MainMenu : Form
    {

        private Form1 _loginForm;
        private MainMenuUtis _mainMenuUtis;
        public MainMenu(MainMenuUtis mainMenuUtis, Form1 loginForm)
        {
            _loginForm = loginForm;
            _mainMenuUtis = mainMenuUtis;
            InitializeComponent();

            TXTwelcome.Text = "Welcome " + _mainMenuUtis.GetUsername() + "!";

        }

        private void BTNsound_Click(object sender, EventArgs e)
        {
            if (_mainMenuUtis.GetSound())
            {
                _mainMenuUtis.SetSound(false);
                _mainMenuUtis.StopMusic();
                BTNsound.Text = "🔊";
                BTNsound.BackColor = Color.Blue;
            }
            else
            {
                _mainMenuUtis.SetSound(true);
                _mainMenuUtis.PlayMusic();
                BTNsound.Text = "🔇";
                BTNsound.BackColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mainMenuUtis.PlayButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string roomName = "";
            int maxPlayers = 0;
            int answerTimeOut = 0;
            int questionCount = 0;
            int roomId;
            _mainMenuUtis.PlayButton();

            CreateRoomData roomData = new CreateRoomData();
            var result = roomData.ShowDialog();
            if (result != DialogResult.OK)
            {
                MessageBox.Show("Error creating room", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            roomName = roomData.roomName;
            maxPlayers = roomData.maxPlayers;
            answerTimeOut = roomData.answerTimeOut;
            questionCount = roomData.questionCount;

            roomId = _mainMenuUtis.GetTriviaRequests().CreateRoom(roomName, maxPlayers, answerTimeOut, questionCount);

            if (roomId == -1)
            {
                MessageBox.Show("Error creating room", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Room room = new Room(_mainMenuUtis.GetUsername(), roomName, maxPlayers, answerTimeOut, questionCount, roomId);
            room.Show();
            this.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            _mainMenuUtis.PlayButton();
            _mainMenuUtis.StopMusic();
            TriviaRequests.instance.Logout();
            TriviaRequests.instance.SetStatus(Constants.LoginMenu);
            _loginForm.Show();
            this.Close();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _mainMenuUtis.PlayButton();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
