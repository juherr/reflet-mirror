using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace UsbApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Splash.launch();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BackgroundTask());
        }

    }
}