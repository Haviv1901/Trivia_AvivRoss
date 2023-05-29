using System;
using System.Collections;
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
    public partial class RoomBrowser : Form
    {
        private SoundManager _soundManager;
        private TriviaRequests _triviaRequests;
        private MainMenu _mainMenu;

        public RoomBrowser(SoundManager soundManager, MainMenu mainMenu)
        {
            _mainMenu = mainMenu;
            _triviaRequests = TriviaRequests.instance;
            _soundManager = soundManager;
            InitializeComponent();
            RefreshRooms();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the room browser. Here you can see all the rooms that are currently open and join them.", "Room Browser", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            RefreshRooms();
        }

        private void RefreshRooms()
        {
            Dictionary<string, int> rooms = _triviaRequests.GetRooms();

            if (rooms == null)
            {
                MessageBox.Show("Error getting rooms", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string key in rooms.Keys)
            {
                Button roomLabel = new Button();

                roomLabel.BackColor = SystemColors.Info;
                roomLabel.Location = FLWroomsListScorll.AutoScrollPosition;
                roomLabel.Name = rooms[key].ToString();
                roomLabel.Size = new Size(75, 23);
                roomLabel.TabIndex = 4;
                roomLabel.Text = key;
                roomLabel.UseVisualStyleBackColor = false;
                roomLabel.FlatStyle = FlatStyle.Flat;
                roomLabel.FlatAppearance.BorderSize = 0;
                roomLabel.Click += button2_Click;

                FLWroomsListScorll.Controls.Add(roomLabel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();

            if (_triviaRequests.JoinRoom(int.Parse(((Button)sender).Name)))
            {
                Room room = new Room(int.Parse(((Button)sender).Name), _soundManager, _mainMenu);
                room.Show();
                this.Hide();
            }
        }

        private void RoomBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            _mainMenu.Show();
        }

        private void BTNjoinButton_Click(object sender, EventArgs e)
        {
            if (_triviaRequests.JoinRoom((int)NUMroomId.Value))
            {
                Room room = new Room(int.Parse(((Button)sender).Name), _soundManager, _mainMenu);
                room.Show();
                this.Hide();
            }
        }

    }
}
