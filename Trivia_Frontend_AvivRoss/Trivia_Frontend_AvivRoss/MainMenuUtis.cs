using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Frontend_AvivRoss
{
    public class MainMenuUtis
    {
        private string _username;
        private bool _sound;
        private TriviaRequests _triviaRequests;

        private SoundPlayer _Button;
        private SoundPlayer _BackgroundMusic;

        public MainMenuUtis(string username)
        {
            this._sound = true;
            this._username = username;

            _Button = new SoundPlayer(Constants.ButtonClick);
            _BackgroundMusic = new SoundPlayer(Constants.BackgroundMusic);

            if (TriviaRequests.instance == null)
                _triviaRequests = new TriviaRequests();
            else
                _triviaRequests = TriviaRequests.instance;

        }

        public void PlayButton()
        {
            _Button.Play();
        }

        public void SetSound(bool sound)
        {
            this._sound = sound;
        }

        public bool GetSound()
        {
            return _sound;
        }

        public string GetUsername()
        {
            return _username;
        }
    }
}
