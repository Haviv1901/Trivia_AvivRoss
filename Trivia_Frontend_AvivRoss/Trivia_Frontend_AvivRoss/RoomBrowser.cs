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
        private List<Button> _buttonHandlers;

        public RoomBrowser(MainUserControl lastControl) : base(lastControl)
        {
            InitializeComponent();
            _buttonHandlers = new List<Button>();
            TMRrefreshRooms.Start();
            
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

            _buttonHandlers.Clear(); // delete all current buttons
            foreach (string key in rooms.Keys)
            {
                Button roomButton = new Button();

                roomButton.BackColor = SystemColors.Info;
                roomButton.Location = FLWroomsListScorll.AutoScrollPosition;
                roomButton.Name = rooms[key].ToString();
                roomButton.Size = new Size(75, 23);
                roomButton.TabIndex = 4;
                roomButton.Text = key;
                roomButton.UseVisualStyleBackColor = false;
                roomButton.FlatStyle = FlatStyle.Flat;
                roomButton.FlatAppearance.BorderSize = 0;
                roomButton.Click += button2_Click;

                Invoke(() =>
                {
                    FLWroomsListScorll.Controls.Add(roomButton);
                });
                _buttonHandlers.Add(roomButton);
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

                TMRrefreshRooms.Stop();
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
            try
            {
                _thread = new Thread(new ThreadStart(RefreshRoomsThread));
                _thread.Start();
            }
            catch (Exception exception)
            {
                TMRrefreshRooms.Stop();
                MessageBox.Show("Error: " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
