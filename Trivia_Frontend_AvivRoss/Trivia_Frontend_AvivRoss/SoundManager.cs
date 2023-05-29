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

        public void LoadMusicButton(Form formToLoadOn)
        {
            // 
            // BTNsound
            // 
            Button BTNsound = new Button();
            BTNsound.BackColor = Color.IndianRed;
            BTNsound.Location = new Point(0, 0);
            BTNsound.Name = "BTNsound";
            BTNsound.Size = new Size(28, 26);
            BTNsound.TabIndex = 1;
            BTNsound.Text = "🔇";
            BTNsound.UseVisualStyleBackColor = false;
            BTNsound.Click += BTNsound_Click;
            formToLoadOn.Controls.Add(BTNsound);

        }

        public static void BTNsound_Click(object sender, EventArgs e)
        {
            if (SoundManager.instance.GetSound())
            {
                SoundManager.instance.SetSound(false);
                SoundManager.instance.StopMusic();
                ((Button)sender).Text = "🔊";
                ((Button)sender).BackColor = Color.Blue;
            }
            else
            {
                SoundManager.instance.SetSound(true);
                SoundManager.instance.PlayMusic();
                ((Button)sender).Text = "🔇";
                ((Button)sender).BackColor = Color.Red;
            }
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
