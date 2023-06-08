using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trivia_Frontend_AvivRoss
{
    public partial class InGame : MainUserControl
    {
        private int _counter;

        private int _questionTimeOut;
        private int _questionCount;
        public InGame(MainUserControl lastLControl, int _questionCount, int _questionTimeOut) : base(lastLControl)
        {
            _counter = 3;
            InitializeComponent();
            this._questionCount = _questionCount;
            this._questionTimeOut = _questionTimeOut;
        }


        // show result button
        private void BTNbackAfterGame_Click(object sender, EventArgs e)
        {
            GameResultScreen gameResultScreen = new GameResultScreen(_lastControl);

            _mainPanel.Controls.Remove(this);
            _mainPanel.Controls.Add(gameResultScreen); // last control here is the main menu.
        }



        private void InGame_Load(object sender, EventArgs e)
        {
            TMRname.Start();
        }

        private void TMRname_Tick(object sender, EventArgs e)
        {
            if (_counter == 0)
            {
                label1.Text = "Starting game...";
                TMRname.Stop();
                Game gameWindow = new Game(_questionTimeOut, _questionCount);
                var result = gameWindow.ShowDialog();
                if (result == DialogResult.OK)
                {
                    label1.Text = "YOU WON !!";
                }
                else
                {
                    label1.Text = "YOU LOST LOLLLLLLLLLLLLLLLLLLLLLLLLL😂😂😂";
                }

                Controls.Add(BTNbackAfterGame);
                Controls.SetChildIndex(BTNbackAfterGame, 0);
                BTNbackAfterGame.Text = "Click me to show game results and go back to main menu.";
            }
            else
            {
                label1.Text = "Game will start in " + _counter;
                _counter--;
            }

        }
    }
}
