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
    public partial class RoomBrowser : MainUserControl
    {

        private Thread _thread;

        public RoomBrowser(MainUserControl lastControl) : base(lastControl)
        {
            InitializeComponent();
            TMRrefreshRooms.Start();
            _thread = new Thread(new ThreadStart(RefreshRoomsThread));
        }


        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the room browser. Here you can see all the rooms that are currently open and join them.", "Room Browser", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// refresh button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            RefreshRooms();
        }

        private void RefreshRoomsThread()
        {
            try
            {
                RefreshRooms();
            }
            catch (Exception e)
            {
            }
        }
        private void RefreshRooms()
        {
            Dictionary<string, int> rooms = _requestHandler.GetRooms();


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

        /// <summary>
        /// join button click. joins the room with the room name that displayes on the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();

            int roomid = int.Parse(((Button)sender).Name);

            if (_requestHandler.JoinRoom(roomid))
            {
                Room room = new Room(_lastControl, roomid, false); // when exiting a room return to main menu

                _mainPanel.Controls.Remove(this);
                _mainPanel.Controls.Add(room);
            }
        }

        /// <summary>
        /// join button click. joins the room with the room id in the numeric box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNjoinButton_Click(object sender, EventArgs e)
        {
            SoundManager.instance.PlayButton();
            int roomid = (int)NUMroomId.Value;
            if (_requestHandler.JoinRoom(roomid))
            {
                Room room = new Room(_lastControl, roomid, false); // when exiting a room return to main menu

                _mainPanel.Controls.Remove(this);
                _mainPanel.Controls.Add(room);
            }
        }

        /// <summary>
        ///  timer to refresh the rooms list, every 3 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TMRrefreshRooms_Tick(object sender, EventArgs e)
        {

            _thread.Start();
        }
    }
}
