using System;
using System.Collections.Generic;
using System.IO;
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

        public static SoundManager? instance = null;

        private SoundPlayer _Button;
        private SoundPlayer _BackgroundMusic;
        private bool _sound;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public SoundManager()
        {
            if (instance == null)
                instance = this;
            else
                return;

            this._sound = true;

            _Button = new SoundPlayer(@"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\ButtonClick.wav");

            _BackgroundMusic = new SoundPlayer(@"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\MainMenuMusic.wav");

        }

        public void PlayMusic()
        {
            if (_BackgroundMusic == null)
            {
                _BackgroundMusic = new SoundPlayer(@"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\MainMenuMusic.wav");
            }
            _BackgroundMusic.PlayLooping();
        }
        public void StopMusic()
        {
            if (_BackgroundMusic == null)
            {
                _BackgroundMusic = new SoundPlayer(@"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\MainMenuMusic.wav");
            }
            _BackgroundMusic.Stop();
        }

        public void PlayWrongAnswer()
        {
            PlaySound(
                @"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\wrong answer.wav");
        }

        public void StartQuizSound()
        {
            PlaySound(
                @"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\game start sound.wav");
        }

        public void PlayCorrectAnswer()
        {
            PlaySound(
                @"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\correct answer.wav");
        }

        public void PlaySound(string path)
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
                    audioFile = new AudioFileReader(path);
                    outputDevice.Init(audioFile);
                }
                outputDevice.Play();
            }
        }

        public void PlayButton()
        {
            PlaySound(
                @"C:\Users\UserPC\Desktop\ekronot\Trivia\trivia_avivross\Trivia_Frontend_AvivRoss\Trivia_Frontend_AvivRoss\music\ButtonClick.wav");
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
