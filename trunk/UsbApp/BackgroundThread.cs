using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UsbLibrary;

namespace UsbApp
{
    class BackgroundThread
    {
        Thread workerThread;
        UsbHidPort usb;

        public BackgroundThread()
        {
            this.usb.ProductId = 81;
            this.usb.VendorId = 1105;
            this.usb.OnSpecifiedDeviceRemoved += new System.EventHandler(this.usb_OnSpecifiedDeviceRemoved);
            this.usb.OnDeviceArrived += new System.EventHandler(this.usb_OnDeviceArrived);
            this.usb.OnDeviceRemoved += new System.EventHandler(this.usb_OnDeviceRemoved);
            this.usb.OnDataRecieved += new UsbLibrary.DataRecievedEventHandler(this.usb_OnDataRecieved);
            this.usb.OnSpecifiedDeviceArrived += new System.EventHandler(this.usb_OnSpecifiedDeviceArrived);
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
                //string rec_data = "Data: ";
                foreach (byte myData in args.data)
                {
                    if (myData != 0)
                        different0 = true;

                    //rec_data += myData.ToString("X") + " ";
                }

                if (different0)
                    processMirrorData(args.data);
            }
        }

        private void processMirrorData(byte[] mirrorData)
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
    }
}
