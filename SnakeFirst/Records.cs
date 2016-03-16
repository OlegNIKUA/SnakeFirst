using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnakeFirst
{
    public partial class Records : Form
    {
        public Records()
        {
            InitializeComponent();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            OpenRecords();
            if (DataRecords.Score != null)
            {
                dataGridView1.Rows.Add(DataRecords.Name, DataRecords.Score);
            }
            
            dataGridView1.Sort(colScore, ListSortDirection.Descending);

        }

        private void Records_FormClosing(object sender, FormClosingEventArgs e)
        {
            Write();
        }

        private void OpenRecords()
        {


            StreamReader myread = new StreamReader("records.txt");
            string[] str;
            int num = 0;
            try
            {
                string[] str1 = myread.ReadToEnd().Split('\n');
                num = str1.Count();
                dataGridView1.RowCount = num;
                for (int i = 0; i < num; i++)
                {
                    str = str1[i].Split('^');
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        try
                        {


                            string data = str[j].Replace("[etot_simvol]", "^");
                            dataGridView1.Rows[i].Cells[j].Value = data;
                        }
                        catch
                        {


                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                myread.Close();
            }


        }

        private void Write()
        {

            StreamWriter myWriter = new StreamWriter("records.txt");

            try
            {

                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {

                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {


                        string data = dataGridView1.Rows[i].Cells[j].Value.ToString().Replace("^", "[etot_simvol]");
                        myWriter.Write(data + "^");
                    }
                    myWriter.WriteLine();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                myWriter.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
