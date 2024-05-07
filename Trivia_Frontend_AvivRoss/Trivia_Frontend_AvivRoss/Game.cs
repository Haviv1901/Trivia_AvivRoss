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
        private int _questionCountIter;
        private int _questionCount;
        private int _questionTimeLeftCount;

        private bool _didUserAnswer = true;
        private int _currQuestionNum = 0;

        public Game(int questionTimeOut, int questionCount)
        {
            InitializeComponent();
            _soundManager = SoundManager.instance;
            _requestHandler = TriviaRequests.instance;
            this._questionCount = questionCount;
            this._questionCountIter = questionCount;
            _questionTimeOut = questionTimeOut;
            _questionTimeLeftCount = questionTimeOut;
            TMRtimeBetweenEachQuestion.Interval = questionTimeOut * 1000;
            TXTquestionLeft.Text = _currQuestionNum + "/" + _questionCount;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            QuestionTimeOut();
            TMRtimeBetweenEachQuestion.Start();
        }

        private void LoadNextQuestion()
        {
            List<string> question;
            try
            {
                question = _requestHandler.GetQuestion();
            }
            catch (Exception e)
            {
                return;
            }
            

            BTNanswer1.Enabled = true;
            BTNanswer2.Enabled = true;
            BTNanswer3.Enabled = true;
            BTNanswer4.Enabled = true;

            BTNanswer1.BackColor = Color.SkyBlue;
            BTNanswer2.BackColor = Color.SkyBlue;
            BTNanswer3.BackColor = Color.SkyBlue;
            BTNanswer4.BackColor = Color.SkyBlue;

            TXTquestion.Text = question[0];
            BTNanswer1.Text = question[1];
            BTNanswer2.Text = question[2];
            BTNanswer3.Text = question[3];
            BTNanswer4.Text = question[4];

            TMRquestionTimer.Stop();
            _questionTimeLeftCount = _questionTimeOut;
            
            TMRquestionTimer.Start();
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMRtimeBetweenEachQuestion.Stop();
            TMRquestionTimer.Stop();
            TMRtimeBetweenEachQuestion.Dispose();
            TMRquestionTimer.Dispose();
            this.Close();
        }

        private void QuestionTimeOut()
        {
            if (_questionCountIter == 0)
            {
                TMRtimeBetweenEachQuestion.Stop();
                end();
            }

            if (!_didUserAnswer)
            {
                RevealAnswer((Object)BTNanswer1); // press the first button
            }
            _didUserAnswer = false;
            _questionCountIter--;
            TXTtimeLeft.ForeColor = Color.Black;
            TXTtimeLeft.Text = _questionTimeOut.ToString();
            TXTquestionLeft.Text = ++_currQuestionNum + "/" + _questionCount;
            LoadNextQuestion();
        }

        private void TMRtimeBetweenEachQuestion_Tick(object sender, EventArgs e)
        {
            QuestionTimeOut();
        }

        private void end()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
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
            _didUserAnswer = true;
            int correctAnswer = 0;
            int answerIndex = int.Parse(((Button)sender).Tag.ToString());// + 1;
            try
            {
                correctAnswer = _requestHandler.SendAnswer(answerIndex - 1) + 1; // button's tag is the answer index
            }
            catch (Exception e)
            {
            }
            

            //MessageBox.Show("The correct answer is: " + correctAnswer);

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
                TurnGreenTheCorrectButton(correctAnswer);
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
                case 1:
                    BTNanswer1.BackColor = Color.Green;
                    break;
                case 2:
                    BTNanswer2.BackColor = Color.Green;
                    break;
                case 3:
                    BTNanswer3.BackColor = Color.Green;
                    break;
                case 4:
                    BTNanswer4.BackColor = Color.Green;
                    break;
            }
        }

        private void TXTquestion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The answer is 3. ;) ");
        }
    }
}
