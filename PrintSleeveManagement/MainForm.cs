using PrintSleeveManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintSleeveManagement
{
    public partial class MainForm : Form
    {
        private Authentication auth;
        Device device;
        public MainForm()
        {
            InitializeComponent();

            auth = new Authentication();
            device = new Device();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {/*
            Authentication auth = new Authentication();
            if (Authentication.Username == null)
            {
                LoginForm loginForm = new LoginForm();
                this.Enabled = false;
                loginForm.Show();
            }/*
            LoginForm loginForm = new LoginForm();
            this.Enabled = false;
            loginForm.Show();/**/

        }

        void CheckInput()
        {
            if (device.CheckInput())
            {
                toolStripStatusDevice.Text = $"Device Input Mode: {Device.InputMode}";
                if (Device.InputMode == Device.DEVICE_INPUT_MODE.SERIAL_PORT)
                {
                    toolStripStatusDevice.Text += $", ComPort: {Device.SerialPortIncoming}";
                }
            }
            else
            {
                MessageBox.Show("Can't use Input Device!\nDetail:" + device.ErrorString + "\nIf you need to use Input Device, please setting Device!");
                
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {/*
            LoginForm loginForm = new LoginForm();
            this.Enabled = false;
            loginForm.Show();*/


        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (Authentication.Username == null)
            {
                LoginForm loginForm = new LoginForm(this);
                this.Enabled = false;
                loginForm.Show();
            }else
            {
                this.Enabled = true;
                toolStripStatusUser.Text = "User by : " + Authentication.Username;
                
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReceiptForm receiptForm = new ReceiptForm();
            receiptForm.MdiParent = this;
            receiptForm.Show();
        }

        private void toolStripPutAway_Click(object sender, EventArgs e)
        {
            PutAwayForm putAwayForm = new PutAwayForm(device);
            putAwayForm.MdiParent = this;
            putAwayForm.Show();
        }

        private void toolStripDevice_Click(object sender, EventArgs e)
        {
            DeviceForm deviceForm = new DeviceForm();
            deviceForm.MdiParent = this;
            deviceForm.Show();
        }

        private void toolStripConnectDevice_Click(object sender, EventArgs e)
        {
            using (WaitForm waitForm = new WaitForm(CheckInput))
            {
                waitForm.ShowDialog(this);
            }/**/
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            device.Close();
        }
    }
}
