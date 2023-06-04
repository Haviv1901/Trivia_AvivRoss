using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    public partial class Room : Form
    {
        private int _roomId;
        private bool _refresh;

        public delegate void AddButton();
        public AddButton myDelegate;

        private SoundManager _soundManager;
        private MainMenu _mainMenu;
        private Thread _thread;

        private Label TXTplayerN;

        public Room(int roomId, SoundManager soundManager, MainMenu main, bool isCreator)
        {
            TXTplayerN = new Label();
            TXTplayerN.AutoSize = true;
            TXTplayerN.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TXTplayerN.Location = new Point(29, 100);
            TXTplayerN.Name = "TXTcreator";
            TXTplayerN.Size = new Size(62, 19);
            TXTplayerN.TabIndex = 1;
            
            _roomId = roomId;
            _soundManager = soundManager;
            _mainMenu = main;

            InitializeComponent();
            Controls.Add(TXTplayerN);
            if (isCreator)
            {
                Controls.Add(button2);
            }

            _soundManager.LoadMusicButton(this);
            TXTroomId.Text += _roomId.ToString();
            myDelegate = new AddButton(AddButtonMethod);
            _thread = new Thread(new ThreadStart(RefreshPlayers));
            _thread.Start();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SoundManager.instance.PlayButton();
            TriviaRequests.instance.CloseOrLeaveRoom();
            this.Close();
        }

        private void Room_FormClose(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            try
            {
                _thread.Interrupt();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            _mainMenu.Show();
        }

        private void BTNrefresh_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            AddButtonMethod();
        }

        private void RefreshPlayers()
        {
            try
            {
                while (true)
                {
                    AddButtonMethod();
                    Thread.Sleep(500);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Room closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    Invoke(() =>
                    {
                        this.Close();
                    });
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }


            }

        }

        private void AddButtonMethod()
        {
            List<string> players;
            Tuple<List<string>, bool, int, int> roomState;
            try
            {
                roomState = TriviaRequests.instance.GetRoomState();
            }
            catch (Exception e) // if room closed, the json parse will fail.
            {
                throw new Exception("Room closed");
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
                MessageBox.Show("Game started!", "Trivia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void StartGame(object sender, EventArgs e)
        {
            SoundManager.instance.PlayButton();
            TriviaRequests.instance.StartGame();
        }
    }
}
