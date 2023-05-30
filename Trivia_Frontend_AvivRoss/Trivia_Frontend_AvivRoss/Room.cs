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
        private bool _isCreator;

        public delegate void AddButton();
        public AddButton myDelegate;

        private SoundManager _soundManager;
        private MainMenu _mainMenu;
        private Thread _thread;

        public Room(int roomId, SoundManager soundManager, MainMenu main, bool isCreator)
        {
            _isCreator = isCreator;
            _roomId = roomId;
            _soundManager = soundManager;
            _mainMenu = main;


            InitializeComponent();
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
            _mainMenu.Show();
        }

        private void BTNrefresh_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            RefreshPlayers();
        }

        private void RefreshPlayers()
        {
            if (BTNrefresh.InvokeRequired)
            {
                try
                {
                    while (true)
                    {
                        this.BeginInvoke(myDelegate);
                        Thread.Sleep(500);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                AddButtonMethod();
            }

        }

        private void AddButtonMethod()
        {
            List<string> players = new List<string>();
            try
            {
                players = TriviaRequests.instance.GetRoomState().Item1;
            }
            catch (Exception e) // if room closed, the json parse will fail.
            {
                try
                {
                    Invoke(() =>
                    {
                        MessageBox.Show("Room closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    });
                }
                catch (Exception a) {}
            }
            

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
