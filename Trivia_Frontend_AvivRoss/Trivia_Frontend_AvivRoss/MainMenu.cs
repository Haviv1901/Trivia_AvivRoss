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

        private LoginPage _loginForm;
        private MainMenuUtis _mainMenuUtis;
        public MainMenu(MainMenuUtis mainMenuUtis, LoginPage loginForm)
        {
            _loginForm = loginForm;
            _mainMenuUtis = mainMenuUtis;
            InitializeComponent();
            _mainMenuUtis.GetSoundManager().LoadMusicButton(this);
            TXTwelcome.Text = "Welcome " + _mainMenuUtis.GetUsername() + "!";

        }



        // Join room button
        private void button1_Click(object sender, EventArgs e)
        {
            SoundManager.instance.PlayButton();

            RoomBrowser room = new RoomBrowser(_mainMenuUtis.GetSoundManager(), this);
            room.Show();
            this.Hide();
        }

        // create room button
        private void button2_Click(object sender, EventArgs e)
        {
            SoundManager.instance.PlayButton();
            string roomName = "";
            int maxPlayers = 0;
            int answerTimeOut = 0;
            int questionCount = 0;
            int roomId;

            CreateRoomData roomData = new CreateRoomData();
            var result = roomData.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            roomName = roomData.roomName;
            maxPlayers = roomData.maxPlayers;
            answerTimeOut = roomData.answerTimeOut;
            questionCount = roomData.questionCount;

            roomId = _mainMenuUtis.GetTriviaRequests().CreateRoom(roomName, maxPlayers, answerTimeOut, questionCount);

            if (roomId == -1)
            {
                return;
            }

            Room room = new Room(roomId, _mainMenuUtis.GetSoundManager(), this, true);
            room.Show();
            this.Hide();
        }

        // logout button
        private void button4_Click(object sender, EventArgs e)
        {
            SoundManager.instance.PlayButton();
            SoundManager.instance.StopMusic();
            TriviaRequests.instance.Logout();
            TriviaRequests.instance.SetStatus(Constants.LoginMenu);
            _loginForm.Show();
            this.Close();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginForm.Show();
        }

        // stats button
        private void button3_Click(object sender, EventArgs e)
        {
            SoundManager.instance.PlayButton();
            Statistics statistics = new Statistics(this, _mainMenuUtis.GetSoundManager(), _mainMenuUtis.GetUsername());
            statistics.Show();
            this.Hide();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
