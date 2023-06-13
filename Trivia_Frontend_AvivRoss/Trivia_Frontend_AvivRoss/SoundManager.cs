using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;

namespace Trivia_Frontend_AvivRoss
{
    public class SoundManager
    {

        public static SoundManager? instance = null;

        private bool _sound;

        private WaveOut waveOut;
        private RawSourceWaveStream audioFile;

        public SoundManager()
        {
            if (instance == null)
                instance = this;
            else
                return;

            this._sound = true;


        }

        public void PlayMusic()
        { 
            if (waveOut == null)
            {
                waveOut = new WaveOut();
                waveOut.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new RawSourceWaveStream(Properties.Resources.MainMenuMusic, new WaveFormat());
                LoopStream loop = new LoopStream(audioFile);
                waveOut.Init(loop);
            }
            waveOut.Play();
        }
        public void StopMusic()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
            }
        }

        public void PlayWrongAnswer()
        {
            PlaySound(Properties.Resources.wrong_answer);
        }

        public void StartQuizSound()
        {
            PlaySound(Properties.Resources.game_start_sound);
        }

        public void PlayCorrectAnswer()
        {
            PlaySound(Properties.Resources.correct_answer);
        }

        public void PlaySound(Stream path)
        {
            if (!_sound)
                return;
            SoundPlayer temp = new SoundPlayer(path);
            temp.Play();
        }

        public void PlayButton()
        {
            PlaySound(Properties.Resources.ButtonClickSound);
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            waveOut.Dispose();
            waveOut = null;
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
