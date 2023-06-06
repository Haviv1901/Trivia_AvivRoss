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
    public partial class MainUserControl : UserControl
    {
        public static TriviaRequests _requestHandler;
        public static SoundManager _soundManager;
        public static Panel _mainPanel;
        protected MainUserControl _lastControl;


        public MainUserControl()
        {
            InitializeComponent();
        }

        public MainUserControl(MainUserControl lastControl) : this()
        {
            _lastControl = lastControl;
        }

        public MainUserControl(SoundManager soundManager, Panel mainPanel) : this()
        {
            _soundManager = soundManager;

            if (TriviaRequests.instance == null)
            {
                _requestHandler = new TriviaRequests();
            }
            else
            {
                _requestHandler = TriviaRequests.instance;
            }

            _mainPanel = mainPanel;
        }

        private void BTNsound_Click(object sender, EventArgs e)
        {
            if (_soundManager.GetSound())
            {
                _soundManager.SetSound(false);
                _soundManager.StopMusic();
                ((Button)sender).Text = "🔊";
                ((Button)sender).BackColor = Color.Blue;
            }
            else
            {
                _soundManager.SetSound(true);
                _soundManager.PlayMusic();
                ((Button)sender).Text = "🔇";
                ((Button)sender).BackColor = Color.Red;
            }
        }

        // Back Button
        protected void button2_Click_1(object sender, EventArgs e)
        {
            _soundManager.PlayButton();


            if (_lastControl == null)
            {
                return;
            }

            if (_lastControl is LoginPage)
            {
                _requestHandler.Logout();
            }

            if (this is Room) // if current window is room window, leave or close rooom
            {
                _requestHandler.CloseOrLeaveRoom();
            }

            _mainPanel.Controls.Remove(this);
            _mainPanel.Controls.Add(_lastControl);

        }
        // exit button
        private void BTNexit_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            _requestHandler.Logout();

            FindForm().Close();
        }

    }
}
