using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SnakeFirst
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formGame());
        }
    }

     static class DataRecords
    {
        public static string Name { get; set; }
        public static string Score { get; set; }


    }

    static class TrackBarValue
    {
        public static int lvlValue { get; set; }
    }
}
