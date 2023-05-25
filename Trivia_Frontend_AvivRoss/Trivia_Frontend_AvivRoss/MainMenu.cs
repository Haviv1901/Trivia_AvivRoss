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
    public partial class MainMenu : Form
    {

        private MainMenuUtis _mainMenuUtis;
        public MainMenu(MainMenuUtis mainMenuUtis)
        {
            _mainMenuUtis = mainMenuUtis;
            InitializeComponent();
        }

        private void BTNsound_Click(object sender, EventArgs e)
        {
            if (_mainMenuUtis.GetSound())
            {
                _mainMenuUtis.SetSound(false);
                BTNsound.Text = "🔊";
                BTNsound.BackColor = Color.Blue;
            }
            else
            {
                _mainMenuUtis.SetSound(true);
                BTNsound.Text = "🔇";
                BTNsound.BackColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mainMenuUtis.PlayButton();
        }
    }
}
