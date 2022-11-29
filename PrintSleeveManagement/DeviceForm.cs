using PrintSleeveManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintSleeveManagement
{
    public partial class DeviceForm : Form
    {
        Device device;

        string outgoingPort;
        string incomingPort;

        public DeviceForm()
        {
            InitializeComponent();

            device = new Device();

            labelActiveSerialPort.Text = Device.SerialPortIncoming;
            string[] listSerialPort = SerialPort.GetPortNames();
            comboBoxOutgoingPort.Items.AddRange(listSerialPort);
            comboBoxIncomingPort.Items.AddRange(listSerialPort);
        }

        private void buttonActivate_Click(object sender, EventArgs e)
        {
            outgoingPort = comboBoxOutgoingPort.SelectedItem.ToString();
            incomingPort = comboBoxIncomingPort.SelectedItem.ToString();

            using (WaitForm waitForm = new WaitForm(ActivateDevice))
            {
                waitForm.ShowDialog(this);
            }
        }

        void ActivateDevice()
        {
            if (device.Activate(outgoingPort, incomingPort))
            {
                MessageBox.Show("Input Device Activate is Successfuly");
            }
            else
            {
                MessageBox.Show("Input Device Activate is Unsuccessfuly!\nPlease check setting and try agian.\nDetaial:\n" + device.ErrorString);
            }
        }
    }
}
