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
    public partial class InGame : MainUserControl
    {
        public InGame(MainUserControl lastLControl) : base(lastLControl)
        {
            _mainPanel.Controls.Add(this);
            InitializeComponent();
            Controls.Remove(BTNbackAfterGame);
            Game gameWindow = new Game();

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
        }

        private void BTNbackAfterGame_Click(object sender, EventArgs e)
        {
            _mainPanel.Controls.Remove(this);
            _mainPanel.Controls.Add(_lastControl); // last control here is the main menu.
        }
    }
}
