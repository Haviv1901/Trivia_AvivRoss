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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            SoundManager sd = new SoundManager();
            LoginPage main = new LoginPage(sd);
            this.Controls.Add(main);
        }
    }
}
