using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trivia_Frontend_AvivRoss
{
    public partial class Statistics : MainUserControl
    {
        private string _username;

        public Statistics(MainUserControl lastControl, string username) : base(lastControl)
        {
            _username = username;

            InitializeComponent();
            RefreshScoresAndStats();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            RefreshScoresAndStats();
        }

        private void RefreshScoresAndStats()
        {
            List<string> stats = _requestHandler.GetPersonalStats();
            Dictionary<string, float> highScores = _requestHandler.GetHighScore();

            TBLpersStats.Controls.Clear();
            TBLhighScores.Controls.Clear();

            AddLabelsToPersStats();

            // list is: [0] Average Answer Time [1] Number of Correct Answers [2] Total Answers [3] Number of Games Played [4] Total Score
            int row = 0;
            foreach (string stat in stats)
            {
                Label info = new Label();
                info.AutoSize = true;
                info.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                info.Location = new Point(5, 106);
                info.Name = "label3";
                info.Size = new Size(40, 24);
                info.TabIndex = 3;
                info.Text = stat;

                TBLpersStats.Controls.Add(info, 1, row);
                row++;
            }

            row = 0;
            foreach (string username in highScores.Keys)
            {
                Label user = new Label();
                Label score = new Label();

                user.AutoSize = true;
                user.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
                user.Name = "label3";
                user.Size = new Size(40, 24);
                user.TabIndex = 3;
                user.Text = username;

                score.AutoSize = true;
                score.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
                score.Name = "label3";
                score.Size = new Size(40, 24);
                score.TabIndex = 3;
                score.Text = highScores[username].ToString();

                TBLhighScores.Controls.Add(user, 0, row);
                TBLhighScores.Controls.Add(score, 1, row);
                row++;
            }

        }

        private void AddLabelsToPersStats()
        {
            TBLpersStats.Controls.Add(label3, 0, 2);
            TBLpersStats.Controls.Add(label1, 0, 0);
            TBLpersStats.Controls.Add(label2, 0, 1);
            TBLpersStats.Controls.Add(label4, 0, 3);
            TBLpersStats.Controls.Add(label5, 0, 4);
        }

    }
}
