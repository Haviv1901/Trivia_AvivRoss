using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Frontend_AvivRoss
{
    public class SoundManager
    {
        private SoundPlayer _Button;
        private SoundPlayer _BackgroundMusic;
        private bool _sound;

        public SoundManager()
        {
            this._sound = true;

            _Button = new SoundPlayer(@"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\ButtonClick.wav");

            _BackgroundMusic = new SoundPlayer(@"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\MainMenuMusic.wav");

        }

        public void PlayMusic()
        {
            _BackgroundMusic.PlayLooping();
        }
        public void StopMusic()
        {
            _BackgroundMusic.Stop();
        }

        public void PlayButton()
        {
            if (_sound)
            {
                _Button.Play();
                Thread.Sleep(1000);
                PlayMusic();
            }
        }

        public void SetSound(bool sound)
        {
            this._sound = sound;
        }

        public bool GetSound()
        {
            return _sound;
        }

    }
}
