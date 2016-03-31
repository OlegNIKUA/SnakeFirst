using System;
using System.IO;
using System.Windows.Forms;

namespace SnakeFirst
{
    public partial class PlayerInfo : Form
    {
        public PlayerInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty) {
                DataRecords.Name = textBox1.Text;

                write();
                Close();
            }
            else
            {
                MessageBox.Show("Ты че?", "Пропиши", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                
            }
            
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void write()
        {

            try
            {

                StreamWriter myfile = new StreamWriter("records.txt", true);
                var data = DataRecords.Name + "^" + DataRecords.Score;
                myfile.WriteLine(data + "^");
                myfile.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
