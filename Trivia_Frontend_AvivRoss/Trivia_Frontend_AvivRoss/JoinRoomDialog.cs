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
    public partial class JoinRoomDialog : Form
    {
        public int RoomId { get; set; }
        public JoinRoomDialog()
        {
            InitializeComponent();
        }

        private void BTNok_Click(object sender, EventArgs e)
        {
            RoomId = (int)NUMroomId.Value;

            if (RoomId < 0)
            {
                DialogResult = DialogResult.No;
                this.Close();
            }

            DialogResult = DialogResult.OK;

        }
    }
}
