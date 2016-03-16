using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            TrackBarValue.lvlValue = trackBar1.Value;
        }
    }
}
