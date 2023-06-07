using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Trivia_Frontend_AvivRoss
{
    public partial class Room : MainUserControl
    {
        private int _roomId;
        private bool _refresh;

        public delegate void AddButton();
        public AddButton myDelegate;

        private Thread _thread;

        private Label TXTplayerN;

        private int _questionTimeOut;
        private int _questionCount;

        public Room(MainUserControl lastControl, int roomId, bool isCreator) : base(lastControl)
        {
            TXTplayerN = new Label();
            TXTplayerN.AutoSize = true;
            TXTplayerN.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TXTplayerN.Location = new Point(29, 100);
            TXTplayerN.Name = "TXTcreator";
            TXTplayerN.Size = new Size(62, 19);
            TXTplayerN.TabIndex = 1;

            _roomId = roomId;

            InitializeComponent();
            Controls.Add(TXTplayerN);
            if (isCreator)
            {
                Controls.Add(button2);
            }

            BTNback.Click -= button2_Click_1;
            BTNback.Click += BackButton;

            TXTroomId.Text += _roomId.ToString();
            myDelegate = new AddButton(RefreshPlayersLabel);
            _thread = new Thread(new ThreadStart(RefreshPlayersThread));
            _thread.Start();
        }

        // NOTE: MUST CALL CloseThread function before calling this function.
        private void StartGame()
        {
            
            InGame gameUserControl = new InGame(_lastControl, _questionCount, _questionTimeOut); // on game end return to the main menu.

            _mainPanel.Controls.Remove(this);
            _mainPanel.Controls.Add(gameUserControl);
        }

        private void CloseThread()
        {
            try
            {
                _thread.Interrupt();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void BackButton(object sender, EventArgs e)
        {
            CloseThread();
            button2_Click_1(sender, e);
        }

        private void BTNrefresh_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            RefreshPlayersLabel();
        }

        private void RefreshPlayersThread()
        {
            try
            {
                while (true)
                {
                    RefreshPlayersLabel();
                    Thread.Sleep(500);
                }
            }
            catch (RoomClosedException e)
            {
                MessageBox.Show("Room closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    Invoke(() =>
                    {
                        _mainPanel.Controls.Remove(this);
                        _mainPanel.Controls.Add(_lastControl);
                    });
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
            catch (Exception e)
            {
                return;
            }
        }

        private void RefreshPlayersLabel()
        {
            List<string> players;
            Tuple<List<string>, bool, int, int> roomState = null;
            try
            {
                roomState = _requestHandler.GetRoomState(); 
            }
            catch (GameStarted e) // game has allready started and the user is in Game handler.
            {
                CloseThread();
            }
            catch (Exception e) // if room closed, the json parse will fail.
            {
                throw new RoomClosedException("Room closed");
            }

            players = roomState.Item1;
            bool isStarted = roomState.Item2;
            string playersString = "";
            foreach (string player in players)
            {

                playersString += "- " + player + "\n";

            }

            Invoke(() =>
            {
                TXTplayerN.Text = playersString;
            });

            if (isStarted)
            {
                
                Invoke(() =>
                {
                    StartGame();
                });
                CloseThread();
            }

        }

        // start game button click
        private void StartGame_buttonClick(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            CloseThread();
            _requestHandler.StartGame();
            StartGame();
        }
    }


}
