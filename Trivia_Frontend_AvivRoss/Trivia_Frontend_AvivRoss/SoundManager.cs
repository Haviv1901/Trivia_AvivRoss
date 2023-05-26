using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Trivia_Frontend_AvivRoss
{
    public class SoundManager
    {
        private SoundPlayer _Button;
        private SoundPlayer _BackgroundMusic;
        private bool _sound;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

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
                if (outputDevice == null)
                {
                    outputDevice = new WaveOutEvent();
                    outputDevice.PlaybackStopped += OnPlaybackStopped;
                }
                if (audioFile == null)
                {
                    audioFile = new AudioFileReader(@"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\ButtonClick.wav");
                    outputDevice.Init(audioFile);
                }
                outputDevice.Play();
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
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
