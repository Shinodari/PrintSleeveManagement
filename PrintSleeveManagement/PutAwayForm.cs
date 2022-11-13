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
    public partial class PutAwayForm : Form
    {
        Receipt receipt;

        BindingSource bindingSource;

        public PutAwayForm()
        {
            InitializeComponent();
        }

        private void PutAwayForm_Load(object sender, EventArgs e)
        {
            setDiplayReceipt(false);
            textBoxPONo.Focus();
        }

        private void setDiplayReceipt(bool alreadyPO)
        {
            if (alreadyPO)
            {
                groupBoxPrintSleeve.Enabled = true;
                groupBoxBluetooth.Enabled = true;

                textBoxPONo.Enabled = false;
                dataGridViewReceipt.Enabled = true;
            }
            else
            {
                groupBoxPrintSleeve.Enabled = false;
                groupBoxBluetooth.Enabled = false;

                textBoxPONo.Enabled = true;
                dataGridViewReceipt.Enabled = false;
            }
        }

        private void commitPO()
        {
            int pONo = Int32.Parse(textBoxPONo.Text);
            receipt = new Receipt(pONo);
            receipt.getReceipt();
            bindingSource = new BindingSource();
            bindingSource.DataSource = receipt.PrintSleeve;
            dataGridViewReceipt.DataSource = bindingSource;
            dataGridViewReceipt.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewReceipt.Columns["Quantity"].DisplayIndex = 2;
        }

        private void textBoxPONo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                commitPO();
            }
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {
            commitPO();
        }
    }
}
