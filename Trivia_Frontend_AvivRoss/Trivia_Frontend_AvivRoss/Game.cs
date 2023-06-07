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

        public Game()
        {
            InitializeComponent();
            _soundManager = SoundManager.instance;
            _requestHandler = TriviaRequests.instance;
        }
    }
}
