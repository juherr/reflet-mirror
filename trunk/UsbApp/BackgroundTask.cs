using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UsbLibrary;

namespace UsbApp
{
    public partial class BackgroundTask : Form
    {
        Configuration maConfiguration = null;
        AboutReflet aboutBox = null;

        public BackgroundTask()
        {
            InitializeComponent();
            notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.WindowState = FormWindowState.Minimized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.Visible=false;
            try
            {
                this.usb1.ProductId = Int32.Parse("1301", System.Globalization.NumberStyles.HexNumber);
                this.usb1.VendorId = Int32.Parse("1DA8", System.Globalization.NumberStyles.HexNumber);
                this.usb1.CheckDevicePresent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void usb_OnDeviceArrived(object sender, EventArgs e)
        {
            //this.lb_message.Items.Add("Found a Device");
        }

        private void usb_OnDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usb_OnDeviceRemoved), new object[] { sender, e });
            }
            else
            {
                //this.lb_message.Items.Add("Device was removed");
            }
        }

        private void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            //this.lb_message.Items.Add("My device was found");
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            usb1.RegisterHandle(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            usb1.ParseMessages(ref m);
            base.WndProc(ref m);	// pass message on to base form
        }

        private void usb_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usb_OnSpecifiedDeviceRemoved), new object[] { sender, e });
            }
            else
            {
                //this.lb_message.Items.Add("My device was removed");
            }
        }

        private void usb_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new DataRecievedEventHandler(usb_OnDataRecieved), new object[] { sender, args });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                bool different0 = false;
                string rec_data = "Data: ";
                foreach (byte myData in args.data)
                {
                    if (myData != 0)
                        different0 = true;

                    rec_data += myData.ToString("X") + " ";
                }

                if (different0)
                    processMirrorData(args.data);
            }
        }

        private void processMirrorData(byte[] mirrorData)
        {
            if (maConfiguration != null)
                maConfiguration.processConfigAction(mirrorData);
            else
                processLaunch(mirrorData);
        }

        private void toolStripClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripConfig_Click(object sender, EventArgs e)
        {
            //if (this.usb1.UnregisterHandle() == false)
            //    Console.WriteLine("fail");
            //this.usb1.StopUsbDevicePresent();
            if (maConfiguration == null)
            {
                maConfiguration = new Configuration();
                maConfiguration.Show();
                maConfiguration.HandleDestroyed += new EventHandler(maConfiguration_HandleDestroyed);
            }
            else
                maConfiguration.Focus();
        }

        void maConfiguration_HandleDestroyed(object sender, EventArgs e)
        {
            maConfiguration = null;
        }

        private void processLaunch(byte[] mirrorData)
        {
            MirrorLogic logic = new MirrorLogic();
            if (mirrorData[1] == 1) //action miroir
            {
                if (mirrorData[2] == 4) //remis à l'endroit
                {
                    //this.lb_read.Items.Insert(0, "Remise à l'endroit du mir:ror");
                }
                else if (mirrorData[2] == 5) // mise à l'envers
                {
                    //this.lb_read.Items.Insert(0, "Retournement du mir:ror");
                }
            }
            else if (mirrorData[1] == 2) //action ztamp
            {
                string idZtamp = String.Empty;
                for (int i = 3; i <= 13; i++)
                    idZtamp += mirrorData[i].ToString("X2");
                if (mirrorData[2] == 1) //dépot
                {
                    logic.doMirrorLogic(idZtamp, Action.POSE);
                }
                else if (mirrorData[2] == 2) // retrait
                {
                    logic.doMirrorLogic(idZtamp, Action.RETIRE);
                }
            }
            else
            {
                Console.WriteLine("tiens, une erreur inconnue est survenue...");
            }
        }

        private void toolStripAbout_Click(object sender, EventArgs e)
        {
            if (aboutBox == null)
            {
                aboutBox = new AboutReflet();
                aboutBox.Show();
                aboutBox.HandleDestroyed += new EventHandler(aboutBox_HandleDestroyed);
            }
            else
                aboutBox.Focus();
        }

        void aboutBox_HandleDestroyed(object sender, EventArgs e)
        {
            aboutBox = null;
        }
    }
}
