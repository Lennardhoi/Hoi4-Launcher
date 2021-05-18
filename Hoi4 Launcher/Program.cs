using System;
using System.Windows.Forms;

namespace Hoi4_Launcher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            //List<string> test = new List<string>();
            //test.Add("-autosave=NEVER");
            //test.Add("-debug");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));
        }
    }
}
