using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;


namespace Trivia_Frontend_AvivRoss
{
    public partial class Room : Form
    {
        private int _roomId;

        private SoundManager _soundManager;
        private MainMenu _mainMenu;

        public Room(int roomId, SoundManager soundManager, MainMenu main)
        {
            _roomId = roomId;
            _soundManager = soundManager;
            _mainMenu = main;


            InitializeComponent();
            TXTroomId.Text += _roomId.ToString();
            RefreshPlayers();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // close room or smth ?

            // if the user exiting the room is the creator kick all ?

            _soundManager.PlayButton();
            this.Close();
        }

        private void Room_FormClose(object sender, EventArgs e)
        {
            _mainMenu.Show();
        }

        private void BTNrefresh_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            RefreshPlayers();
        }

        private void RefreshPlayers()
        {
            List<string> players = TriviaRequests.instance.GetPlayersInRoom(_roomId);

            int i = 20;

            foreach (string player in players)
            {
                Label TXTplayerN = new Label();
                TXTplayerN.AutoSize = true;
                TXTplayerN.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
                TXTplayerN.Location = new Point(29, 80 + i);
                TXTplayerN.Name = "TXTcreator";
                TXTplayerN.Size = new Size(62, 19);
                TXTplayerN.TabIndex = 1;
                TXTplayerN.Text = "- " + player;
                Controls.Add(TXTplayerN);
                i += 20;
            }

        }
    }
}
