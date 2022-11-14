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

                textBoxPONo.Enabled = false;
                dataGridViewReceipt.Enabled = true;
            }
            else
            {
                groupBoxPrintSleeve.Enabled = false;

                textBoxPONo.Enabled = true;
                dataGridViewReceipt.Enabled = false;
            }
        }

        private void commitPO()
        {
            setDiplayReceipt(true);

            int pONo = Int32.Parse(textBoxPONo.Text);
            receipt = new Receipt(pONo);
            receipt.getReceipt();
            bindingSource = new BindingSource();
            bindingSource.DataSource = receipt.PrintSleeve;
            dataGridViewReceipt.DataSource = bindingSource;
            dataGridViewReceipt.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewReceipt.Columns["Available"].DisplayIndex = 3;
            dataGridViewReceipt.Columns["Quantity"].DisplayIndex = 2;
            bindingSource.PositionChanged += new EventHandler(rowChanged);

            labelPartNo.Text = dataGridViewReceipt.Rows[0].Cells[3].Value.ToString();
        }

        private void rowChanged(object sender, System.EventArgs e)
        {
            labelPartNo.Text = dataGridViewReceipt.Rows[bindingSource.Position].Cells[3].Value.ToString();
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
