using QB.WindowApp;
using System;
using System.Windows.Forms;

namespace QB.WindowApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGeneralReport());
        }
    }
}
