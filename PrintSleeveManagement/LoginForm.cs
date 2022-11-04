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
    public partial class LoginForm : Form
    {
        private MainForm mainForm;
        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void submit()
        {
            if (textBoxUsername.Text.Equals("") )
            {
                this.ActiveControl = textBoxUsername;
                return;
            } else if (textBoxPassword.Text.Equals(""))
            {
                this.ActiveControl = textBoxPassword;
                return;
            }

            Authentication authentication = new Authentication();
            Authentication.AUTHENTICATION_RESULT result = authentication.login(textBoxUsername.Text, textBoxPassword.Text);
            if (result == Authentication.AUTHENTICATION_RESULT.SUCCESS)
            {
                this.Close();
                mainForm.Activate();
            }
        }
    }
}
