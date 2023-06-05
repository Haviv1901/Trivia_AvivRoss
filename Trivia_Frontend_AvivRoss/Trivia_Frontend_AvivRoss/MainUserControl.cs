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
        protected TriviaRequests _requestHandler;
        protected SoundManager soundManager;
        protected MainUserControl LastControl;

        public MainUserControl()
        {
            InitializeComponent();
        }
        public MainUserControl(SoundManager soundManager, MainUserControl lastControl) : this(soundManager)
        {
            this.LastControl = lastControl;
        }

        public MainUserControl(SoundManager soundManager)
        {
            InitializeComponent();
            this.soundManager = soundManager;
            _requestHandler = new TriviaRequests();
        }

        private void BTNsound_Click(object sender, EventArgs e)
        {
            if (soundManager.GetSound())
            {
                soundManager.SetSound(false);
                soundManager.StopMusic();
                ((Button)sender).Text = "🔊";
                ((Button)sender).BackColor = Color.Blue;
            }
            else
            {
                soundManager.SetSound(true);
                soundManager.PlayMusic();
                ((Button)sender).Text = "🔇";
                ((Button)sender).BackColor = Color.Red;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            soundManager.PlayButton();
            Controls.Remove(this);
            Controls.Add(LastControl);
        }
    }
}
