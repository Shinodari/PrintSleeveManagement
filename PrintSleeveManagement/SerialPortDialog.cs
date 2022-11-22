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
    public partial class SerialPortDialog : Form
    {
        public string PortName { get; set; }
        public SerialPortDialog()
        {
            InitializeComponent();
        }

        private void SerialPortDialog_Load(object sender, EventArgs e)
        {
            string[] port = SerialPort.GetPortNames();
            comboBoxSerialPort.Items.AddRange(port);
            comboBoxSerialPort.SelectedIndex = 0;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            this.PortName = comboBoxSerialPort.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
        }

        public new DialogResult Show()
        {
            return (ShowDialog());
        }
    }
}
