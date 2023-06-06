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
    public partial class MainMenu : MainUserControl
    {

        private string _username;
        public MainMenu(string username, MainUserControl lastControl) : base(lastControl)
        {
            _username = username;
            InitializeComponent();
            TXTwelcome.Text = "Welcome " + username + "!";
            _soundManager.PlayMusic();
        }



        // Join room button
        private void button1_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();

            RoomBrowser room = new RoomBrowser(this);
            _mainPanel.Controls.Remove(this);
            _mainPanel.Controls.Add(room);
        }

        // create room button
        private void button2_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
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

            roomId = _requestHandler.CreateRoom(roomName, maxPlayers, answerTimeOut, questionCount);

            if (roomId == -1)
            {
                return;
            }

            Room room = new Room(this, roomId, true);
            _mainPanel.Controls.Remove(this);
            _mainPanel.Controls.Add(room);
        }


        // stats button
        private void button3_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            Statistics statistics = new Statistics(this, _username);
            _mainPanel.Controls.Remove(this);
            _mainPanel.Controls.Add(statistics);
        }


    }
}
