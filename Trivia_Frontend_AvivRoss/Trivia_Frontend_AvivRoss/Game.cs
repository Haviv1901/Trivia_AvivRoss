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
    public partial class Game : Form
    {

        private SoundManager _soundManager;
        private TriviaRequests _requestHandler;

        private int _questionTimeOut;
        private int _questionCount;
        private int _questionTimeLeftCount;

        public Game(int questionTimeOut, int questionCount)
        {
            InitializeComponent();
            _soundManager = SoundManager.instance;
            _requestHandler = TriviaRequests.instance;
            this._questionCount = questionCount;
            _questionTimeLeftCount = questionTimeOut;
            TMRtimeBetweenEachQuestion.Interval = questionTimeOut * 1000;

        }

        private void Game_Load(object sender, EventArgs e)
        {
            QuestionTimeOut();
            TMRtimeBetweenEachQuestion.Start();
        }

        private void LoadNextQuestion()
        {
            List<string> question = _requestHandler.GetQuestion();

            TXTquestion.Text = question[0];
            BTNanswer1.Text = question[1];
            BTNanswer2.Text = question[2];
            BTNanswer3.Text = question[3];
            BTNanswer4.Text = question[4];

            TMRquestionTimer.Stop();
            TMRquestionTimer.Start();
        }

        private void QuestionTimeOut()
        {
            if (_questionCount == 0)
            {
                TMRtimeBetweenEachQuestion.Stop();
                end();
            }
            
            _questionCount--;
            LoadNextQuestion();
        }

        private void TMRtimeBetweenEachQuestion_Tick(object sender, EventArgs e)
        {
            QuestionTimeOut();
            
        }

        private void end()
        {
            // get result, print on screen and have everyone leave the game.
        }

        private void TMRquestionTimer_Tick_1(object sender, EventArgs e)
        {
            _questionTimeLeftCount--;
            if (_questionTimeLeftCount <= 3)
            {
                TXTtimeLeft.ForeColor = Color.Red;
            }

            TXTtimeLeft.Text = _questionTimeLeftCount.ToString();
        }

        private void RevealAnswer(object sender)
        {
            int correctAnswer = 0;
            int answerIndex = int.Parse(((Button)sender).Tag.ToString());
            // correctAnswer = _requestHandler.SendAnswer(int.Parse(((Button)sender).Tag.ToString())); // button's tag is the answer index

            BTNanswer1.Enabled = false;
            BTNanswer2.Enabled = false;
            BTNanswer3.Enabled = false;
            BTNanswer4.Enabled = false;

            if (correctAnswer == answerIndex)
            {
                _soundManager.PlayCorrectAnswer();
                ((Button)sender).BackColor = Color.Green;
            }
            else
            {
                _soundManager.PlayWrongAnswer();
                ((Button)sender).BackColor = Color.Red;
                TurnGreenTheCorrectButton(answerIndex);
            }
        }

        private void BTNanswer1_Click(object sender, EventArgs e)
        {
            RevealAnswer(sender);
        }

        private void BTNanswer2_Click(object sender, EventArgs e)
        {
            RevealAnswer(sender);
        }

        private void BTNanswer3_Click(object sender, EventArgs e)
        {
            RevealAnswer(sender);
        }

        private void BTNanswer4_Click(object sender, EventArgs e)
        {
            RevealAnswer(sender);
        }

        private void TurnGreenTheCorrectButton(int tag)
        {
            switch (tag)
            {
                case 0:
                    BTNanswer1.BackColor = Color.Green;
                    break;
                case 1:
                    BTNanswer2.BackColor = Color.Green;
                    break;
                case 2:
                    BTNanswer3.BackColor = Color.Green;
                    break;
                case 3:
                    BTNanswer4.BackColor = Color.Green;
                    break;
            }
        }
    }
}
