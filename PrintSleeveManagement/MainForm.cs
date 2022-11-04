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
        public MainForm()
        {
            InitializeComponent();

            auth = new Authentication();
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
    }
}
