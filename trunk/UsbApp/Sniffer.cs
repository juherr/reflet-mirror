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
    public partial class Sniffer : Form
    {
        public Sniffer()
        {
            InitializeComponent();
            try
            {
                this.usb.ProductId = Int32.Parse("1301", System.Globalization.NumberStyles.HexNumber);
                this.usb.VendorId = Int32.Parse("1DA8", System.Globalization.NumberStyles.HexNumber);
                this.usb.CheckDevicePresent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void usb_OnDeviceArrived(object sender, EventArgs e)
        {
            this.lb_message.Items.Add("Found a Device");
        }

        private void usb_OnDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usb_OnDeviceRemoved), new object[] { sender, e });
            }
            else
            {
                this.lb_message.Items.Add("Device was removed");
            }
        }

        private void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            this.lb_message.Items.Add("My device was found");
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            usb.RegisterHandle(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            usb.ParseMessages(ref m);
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
                this.lb_message.Items.Add("My device was removed");
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
                    //this.lb_read.Items.Insert(0, rec_data);
            }
        }

        private void processMirrorData(byte[] mirrorData)
        {
            if (mirrorData[1] == 1) //action miroir
            {
                if (mirrorData[2] == 4) //remis à l'endroit
                {
                    this.lb_read.Items.Insert(0, "Remise à l'endroit du mir:ror");
                }
                else if (mirrorData[2] == 5) // mise à l'envers
                {
                    this.lb_read.Items.Insert(0, "Retournement du mir:ror");
                }
            }
            else if (mirrorData[1] == 2) //action ztamp
            {
                string idZtamp = String.Empty;
                for (int i = 3; i <= 13; i++)
                    idZtamp += mirrorData[i].ToString("X2");
                if (mirrorData[2] == 1) //dépot
                {
                    this.lb_read.Items.Insert(0, String.Format("Ztamp posé (ID:{0})",idZtamp));
                }
                else if (mirrorData[2] == 2) // retrait
                {
                    this.lb_read.Items.Insert(0, String.Format("Ztamp retiré (ID:{0})", idZtamp));
                }
            }
            else
            {
                this.lb_read.Items.Insert(0, "Action inconnue");
            }
            //Console.WriteLine();
            //this.lb_read.Items.Insert(0, rec_data);
        }
    }
}