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
    public partial class Room : Form
    {
        private string creator;
        private string roomName;
        private int maxPlayers;
        private int answerTimeOut;
        private int questionCount;
        private int roomId;

        private SoundManager _soundManager;
        private MainMenu _mainMenu;

        public Room(string creator, string roomName, int maxPlayers, int answerTimeOut,
            int questionCount, int roomId, SoundManager soundManager, MainMenu main)
        {

            _soundManager = soundManager;
            _mainMenu = main;

            this.creator = creator;
            this.roomName = roomName;
            this.maxPlayers = maxPlayers;
            this.answerTimeOut = answerTimeOut;
            this.questionCount = questionCount;
            this.roomId = roomId;
            TXTroomId.Text = "Room Id: " + roomId.ToString();
            TXTroomName.Text = roomName;
            TXTcreatorName.Text = creator;
            TXTmaxPlayers.Text += maxPlayers.ToString();
            TXTanswerTimeOut.Text += answerTimeOut.ToString();
            TXTnumOfQuestions.Text += questionCount.ToString();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // close room or smth ?
            
            // if the user exiting the room is the creator kick all ?

            this.Close();
        }

        private void Room_FormClose(object sender, EventArgs e)
        {
            _mainMenu.Show();
        }
    }
}
