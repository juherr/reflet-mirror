namespace UsbApp
{
    partial class Sniffer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_recieved = new System.Windows.Forms.Label();
            this.lb_messages = new System.Windows.Forms.Label();
            this.lb_message = new System.Windows.Forms.ListBox();
            this.gb_details = new System.Windows.Forms.GroupBox();
            this.lb_read = new System.Windows.Forms.ListBox();
            this.usb = new UsbLibrary.UsbHidPort(this.components);
            this.gb_details.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_recieved
            // 
            this.lb_recieved.AutoSize = true;
            this.lb_recieved.Location = new System.Drawing.Point(229, 16);
            this.lb_recieved.Name = "lb_recieved";
            this.lb_recieved.Size = new System.Drawing.Size(82, 13);
            this.lb_recieved.TabIndex = 4;
            this.lb_recieved.Text = "Recieved Data:";
            // 
            // lb_messages
            // 
            this.lb_messages.AutoSize = true;
            this.lb_messages.Location = new System.Drawing.Point(8, 16);
            this.lb_messages.Name = "lb_messages";
            this.lb_messages.Size = new System.Drawing.Size(80, 13);
            this.lb_messages.TabIndex = 7;
            this.lb_messages.Text = "Usb Messages:";
            // 
            // lb_message
            // 
            this.lb_message.FormattingEnabled = true;
            this.lb_message.Location = new System.Drawing.Point(11, 32);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(110, 329);
            this.lb_message.TabIndex = 6;
            // 
            // gb_details
            // 
            this.gb_details.Controls.Add(this.lb_read);
            this.gb_details.Controls.Add(this.lb_messages);
            this.gb_details.Controls.Add(this.lb_message);
            this.gb_details.Controls.Add(this.lb_recieved);
            this.gb_details.ForeColor = System.Drawing.Color.White;
            this.gb_details.Location = new System.Drawing.Point(12, 12);
            this.gb_details.Name = "gb_details";
            this.gb_details.Size = new System.Drawing.Size(428, 377);
            this.gb_details.TabIndex = 6;
            this.gb_details.TabStop = false;
            this.gb_details.Text = "Device Details:";
            // 
            // lb_read
            // 
            this.lb_read.FormattingEnabled = true;
            this.lb_read.Location = new System.Drawing.Point(127, 32);
            this.lb_read.Name = "lb_read";
            this.lb_read.Size = new System.Drawing.Size(285, 329);
            this.lb_read.TabIndex = 8;
            // 
            // usb
            // 
            this.usb.ProductId = 81;
            this.usb.VendorId = 1105;
            this.usb.OnSpecifiedDeviceRemoved += new System.EventHandler(this.usb_OnSpecifiedDeviceRemoved);
            this.usb.OnDeviceArrived += new System.EventHandler(this.usb_OnDeviceArrived);
            this.usb.OnDeviceRemoved += new System.EventHandler(this.usb_OnDeviceRemoved);
            this.usb.OnDataRecieved += new UsbLibrary.DataRecievedEventHandler(this.usb_OnDataRecieved);
            this.usb.OnSpecifiedDeviceArrived += new System.EventHandler(this.usb_OnSpecifiedDeviceArrived);
            // 
            // Sniffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(453, 401);
            this.Controls.Add(this.gb_details);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Sniffer";
            this.Text = "Mir:ror Test App";
            this.gb_details.ResumeLayout(false);
            this.gb_details.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_recieved;
        private System.Windows.Forms.Label lb_messages;
        private System.Windows.Forms.ListBox lb_message;
        private System.Windows.Forms.GroupBox gb_details;
        private UsbLibrary.UsbHidPort usb;
        private System.Windows.Forms.ListBox lb_read;

    }
}

