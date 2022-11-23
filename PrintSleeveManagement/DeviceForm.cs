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
        public DeviceForm()
        {
            InitializeComponent();

            device = new Device();

            string[] listSerialPort = SerialPort.GetPortNames();
            listBoxSerialPort.Items.AddRange(listSerialPort);
        }

        private void buttonActivate_Click(object sender, EventArgs e)
        {
            List<string> listPortName = new List<string>();
            foreach (string portName in listBoxSerialPort.SelectedItems)
            {
                listPortName.Add(portName);
            }

            device.Activate(listPortName);
        }
    }
}
