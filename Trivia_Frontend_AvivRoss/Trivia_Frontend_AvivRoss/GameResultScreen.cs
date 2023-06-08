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
            Dictionary<string, string> results = _requestHandler.GetGameResult();
            string scores = "";
            int i = 1;
            foreach (var username in results.Keys)
            {
                if (username == "status")
                {
                    continue;
                }
                scores += i + ". " + username + " - " + results[username] + "\n";
                i++;
            }
            TXTscores.Text = scores;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("mad cuz u didnt win ha ????? LOL😂😂😂😂😂😂");
        }
    }
}
