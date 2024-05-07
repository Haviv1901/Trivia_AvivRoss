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
    public partial class GameResultScreen : MainUserControl
    {

        public GameResultScreen(MainUserControl lastControl) : base(lastControl)
        {
            InitializeComponent();
        }

        private void GameResultScreen_Load(object sender, EventArgs e)
        {
            List<Tuple<string, float, int, bool>> results = _requestHandler.GetGameResult();
            string scores = "";

            foreach (var user in results)
            {
                scores += "- " + user.Item1 + " - Average answer Time: " + user.Item2 + " Correct Answers: " +
                          user.Item3;
                if (user.Item4)
                    scores += " - Winner!";
                scores += "\n";

            }
            TXTscores.Text = scores;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("mad cuz u didnt win ha ????? LOL😂😂😂😂😂😂");
        }
    }
}
