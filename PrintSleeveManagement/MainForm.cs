﻿using PrintSleeveManagement.Models;
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
        bool showOverview;
        public MainForm()
        {
            InitializeComponent();

            auth = new Authentication();
            device = new Device();
            showOverview = false;
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

            //CallOverview();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (Authentication.Username == null)
            {
                LoginForm loginForm = new LoginForm(this);
                this.Enabled = false;
                loginForm.Show();
            }
            else
            {
                this.Enabled = true;
                toolStripStatusUser.Text = "User by : " + Authentication.Username;
                if (!showOverview)
                {
                    showOverview = true;
                    CallOverview();
                }
            }
        }

        private void CallOverview()
        {
            OverviewForm overviewForm = new OverviewForm();
            overviewForm.MdiParent = this;
            overviewForm.Show();
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

        private void toolStripButtonPick_Click(object sender, EventArgs e)
        {
            AllocateForm pickForm = new AllocateForm();
            pickForm.MdiParent = this;
            pickForm.Show();
        }

        private void toolStripButtonStage_Click(object sender, EventArgs e)
        {
            PickForm stageForm = new PickForm();
            stageForm.MdiParent = this;
            stageForm.Show();
        }

        private void toolStripButtonBalance_Click(object sender, EventArgs e)
        {
            BalanceForm balanceForm = new BalanceForm();
            balanceForm.MdiParent = this;
            balanceForm.Show();
        }

        private void toolStripButtonShip_Click(object sender, EventArgs e)
        {
            ShipForm shipForm = new ShipForm();
            shipForm.MdiParent = this;
            shipForm.Show();
        }

        private void toolStripButtonMove_Click(object sender, EventArgs e)
        {
            MoveForm moveForm = new MoveForm();
            moveForm.MdiParent = this;
            moveForm.Show();
        }
    }
}
