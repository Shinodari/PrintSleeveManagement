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
            
            Dictionary<int, string> inputModeList = new Dictionary<int, string>();
            foreach (Device.DEVICE_INPUT_MODE enumInputDevice in Enum.GetValues(typeof(Device.DEVICE_INPUT_MODE)))
            {
                inputModeList.Add((int)enumInputDevice, enumInputDevice.ToString());
            }
            comboBoxInputMode.DataSource = new BindingSource(inputModeList, null);
            comboBoxInputMode.DisplayMember = "Value";
            comboBoxInputMode.ValueMember = "Key";

            for (int i = 0;i < comboBoxInputMode.Items.Count; i++)
            {
                if (((KeyValuePair<int, string>)comboBoxInputMode.Items[i]).Key == (int) Device.InputMode)
                {
                    comboBoxInputMode.SelectedIndex = i;
                    break;
                }
            }

            labelActiveSerialPort.Text = Device.SerialPortIncoming;
            string[] listSerialPort = SerialPort.GetPortNames();
            comboBoxOutgoingPort.Items.AddRange(listSerialPort);
            if (comboBoxOutgoingPort.Items.Count > 0)
                comboBoxOutgoingPort.SelectedIndex = 0;
            comboBoxIncomingPort.Items.AddRange(listSerialPort);
            if (comboBoxIncomingPort.Items.Count > 0)
                comboBoxIncomingPort.SelectedIndex = 0;
        }

        private void buttonActivate_Click(object sender, EventArgs e)
        {
            if (comboBoxInputMode.SelectedItem.ToString() == Device.DEVICE_INPUT_MODE.SERIAL_PORT.ToString())
            {
                outgoingPort = comboBoxOutgoingPort.SelectedItem.ToString();
                incomingPort = comboBoxIncomingPort.SelectedItem.ToString();
                using (WaitForm waitForm = new WaitForm(ActivateDevice))
                {
                    waitForm.ShowDialog(this);
                }
            }
            else
            {
                Device.InputMode = (Device.DEVICE_INPUT_MODE)((KeyValuePair<int, string>)comboBoxInputMode.SelectedItem).Key;
                MessageBox.Show("Input Device Activate is Successfuly");
            }
        }

        void ActivateDevice()
        {
            if (device.Activate(outgoingPort, incomingPort))
            {
                Device.InputMode = (Device.DEVICE_INPUT_MODE) ((KeyValuePair<int, string>)comboBoxInputMode.SelectedItem).Key;
                Device.SerialPortOutgoing = comboBoxOutgoingPort.SelectedItem.ToString();
                Device.SerialPortIncoming = comboBoxIncomingPort.SelectedItem.ToString();
                MessageBox.Show("Input Device Activate is Successfuly");
            }
            else
            {
                MessageBox.Show("Input Device Activate is Unsuccessfuly!\nPlease check setting and try agian.\nDetaial:\n" + device.ErrorString);
            }
        }
    }
}
