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
    public partial class OverviewForm : Form
    {
        public OverviewForm()
        {
            InitializeComponent();
        }

        private void OverviewForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
        }

        private void OverviewForm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
