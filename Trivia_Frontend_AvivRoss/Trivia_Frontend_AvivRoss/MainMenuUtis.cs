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

        private TriviaRequests _triviaRequests;

        private SoundManager _SoundManager;

        public MainMenuUtis(string username)
        {
            this._username = username;
            if (TriviaRequests.instance == null)
                _triviaRequests = new TriviaRequests();
            else
                _triviaRequests = TriviaRequests.instance;

            _SoundManager = new SoundManager();
            _SoundManager.PlayMusic(); // start background music
        }

        public TriviaRequests GetTriviaRequests()
        {
            return _triviaRequests;
        }

        public string GetUsername()
        {
            return _username;
        }




        public void PlayMusic()
        {
            _SoundManager.PlayMusic();
        }
        public void StopMusic()
        {
            _SoundManager.StopMusic();
        }

        public void PlayButton()
        {
            _SoundManager.PlayButton();
        }

        public void SetSound(bool sound)
        {
            _SoundManager.SetSound(sound);
        }

        public bool GetSound()
        {
            return _SoundManager.GetSound();
        }
    }
}
