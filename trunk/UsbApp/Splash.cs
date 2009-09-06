using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UsbApp
{
    public partial class Splash : Form
    {
        static Form formSplash = null;

        public static void launch()
        {
            Thread thread = new Thread(new ThreadStart(showForm));
            thread.IsBackground = true;
            thread.Start();
            Thread.Sleep(1000);
            stop();
        }

        public static void stop()
        {
            formSplash.Invoke(new MethodInvoker(delegate { formSplash.Close(); formSplash.Dispose(); }));
        }


        private static void showForm()
        {
            if (formSplash == null) { formSplash = new Splash(); }
            formSplash.ShowDialog();
        }

        public Splash()
        {
            InitializeComponent();
        }
    }
}
