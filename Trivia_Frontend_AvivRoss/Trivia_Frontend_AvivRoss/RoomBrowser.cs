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

        private Thread _thread;

        public RoomBrowser(SoundManager soundManager, MainMenu mainMenu)
        {
            _mainMenu = mainMenu;
            _triviaRequests = TriviaRequests.instance;
            _soundManager = soundManager;

            InitializeComponent();
            _soundManager.LoadMusicButton(this);
            _thread = new Thread(new ThreadStart(RefreshRoomsThread));
            _thread.Start();
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

        private void RefreshRoomsThread()
        {
            try
            {
                while (true)
                {
                    RefreshRooms();
                    Thread.Sleep(3000);
                }
            }
            catch (Exception e)
            {
            }
        }
        private void RefreshRooms()
        {
            Dictionary<string, int> rooms = _triviaRequests.GetRooms();

            if (rooms == null)
            {
                MessageBox.Show("Error getting rooms", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Invoke(() =>
            {
                FLWroomsListScorll.Controls.Clear();
            });
            

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

                Invoke(() =>
                {
                    FLWroomsListScorll.Controls.Add(roomLabel);
                });
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();

            int roomid = int.Parse(((Button)sender).Name);

            if (_triviaRequests.JoinRoom(roomid))
            {
                Room room = new Room(roomid, _soundManager, _mainMenu, false);
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
            SoundManager.instance.PlayButton();
            this.Close();
            _mainMenu.Show();
        }

        private void BTNjoinButton_Click(object sender, EventArgs e)
        {
            SoundManager.instance.PlayButton();
            int roomid = (int)NUMroomId.Value;
            if (_triviaRequests.JoinRoom(roomid))
            {
                Room room = new Room(roomid, _soundManager, _mainMenu, false);
                room.Show();
                this.Hide();
            }
        }

    }
}
