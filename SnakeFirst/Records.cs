using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
            //if (DataRecords.Score != null)
            //{
            //    dataGridView1.Rows.Add(DataRecords.Name, DataRecords.Score);
            //}

            dataGridView1.Sort(colScore, ListSortDirection.Descending);
        }

        private void Records_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Write();
        }

        private void OpenRecords()
        {
            var myread = new StreamReader("records.txt");
            string[] str;
            var num = 0;
            try
            {
                var str1 = myread.ReadToEnd().Split('\n');
                num = str1.Count();
                dataGridView1.RowCount = num;
                for (var i = 0; i < num; i++)
                {
                    str = str1[i].Split('^');
                    for (var j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        try
                        {
                            var data = str[j].Replace("[etot_simvol]", "^");
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

        //private void Write()
        //{
        //    var myWriter = new StreamWriter("records.txt");

        //    try
        //    {
        //        for (var i = 0; i < dataGridView1.RowCount - 1; i++)
        //        {
        //            for (var j = 0; j < dataGridView1.ColumnCount; j++)
        //            {
        //                var data = dataGridView1.Rows[i].Cells[j].Value.ToString();
        //                myWriter.Write(data + "^");
        //            }
        //            myWriter.WriteLine();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        myWriter.Close();
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
