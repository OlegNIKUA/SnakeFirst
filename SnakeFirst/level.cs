using System;
using System.Windows.Forms;

namespace SnakeFirst
{
    public partial class level : Form
    {
        public level()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void level_FormClosing(object sender, FormClosingEventArgs e)
        {
            TrackBarValue.LvlValue = trackBar1.Value;
        }
    }
}