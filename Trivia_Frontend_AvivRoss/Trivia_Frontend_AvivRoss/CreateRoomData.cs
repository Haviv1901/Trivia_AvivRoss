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
    public partial class CreateRoomData : Form
    {
        public string roomName { get; set; }
        public int maxPlayers { get; set; }
        public int answerTimeOut { get; set; }
        public int questionCount { get; set; }

        public CreateRoomData()
        {
            InitializeComponent();
        }

        private void TXTroomName_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void BTNok_Click(object sender, EventArgs e)
        {
            roomName = TXTroomName.Text;
            maxPlayers = (int)NUMmaxPlayers.Value;
            answerTimeOut = (int)NUManswerTimeOut.Value;
            questionCount = (int)NUMquestuinCount.Value;

            if (roomName == "")
            {
                TXTmsg.Text = "Please enter a room name";
                return;
            }

            if (maxPlayers < 2)
            {
                TXTmsg.Text = "Max Players must be at least 2";
                return;
            }

            if (answerTimeOut < 5)
            {
                TXTmsg.Text = "Answer Time Out must be at least 5";
                return;
            }

            if (questionCount < 3)
            {
                TXTmsg.Text = "Question Count must be at least 3";
                return;
            }

            // if passed all the tests.
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
