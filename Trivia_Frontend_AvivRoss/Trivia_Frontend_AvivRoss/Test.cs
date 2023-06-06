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
            Panel panel = new Panel();

            LoginPage main = new LoginPage(sd, panel);

            panel.AutoSize = false;
            panel.Size = new Size(816, 489); 

            panel.Controls.Add(main);
            Controls.Add(panel);
            panel.Visible = true;
        }
    }

}
