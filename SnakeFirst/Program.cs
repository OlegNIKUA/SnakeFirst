using System;
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
            Application.Run(new FormGame());
        }
    }

     static class DataRecords
    {
        public static string Name { get; set; }
        public static string Score { get; set; }


    }

    static class TrackBarValue
    {
        public static int LvlValue { get; set; }
    }
}
