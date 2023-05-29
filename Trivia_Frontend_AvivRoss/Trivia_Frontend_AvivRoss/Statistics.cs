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
    public partial class Statistics : Form
    {
        private MainMenu _mainMenu;
        private SoundManager _soundManager;
        private string _username;

        public Statistics(MainMenu mainMenu, SoundManager soundManager, string username)
        {
            _username = username;
            _soundManager = soundManager;
            _mainMenu = mainMenu;
            InitializeComponent();
        }

        private void GetStatistics()
        {
            // get satats and show them on the form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _soundManager.PlayButton();
            _mainMenu.Show();
            this.Close();
        }

        private void Statistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();
        }
    }
}
