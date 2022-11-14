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
    public partial class PODialog : Form
    {
        public int PONo { get; set; }

        Receipt receipt;

        BindingSource bindingSource;
        public PODialog()
        {
            InitializeComponent();

            receipt = new Receipt();
            bindingSource = new BindingSource();
            bindingSource.DataSource = receipt.GetAllPO();
            dataGridViewPO.DataSource = bindingSource;

        }

        public new DialogResult Show()
        {
            Text = "PO View";
            return (ShowDialog());
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.PONo = Int32.Parse(dataGridViewPO.CurrentRow.Cells[0].Value.ToString());
            this.DialogResult = DialogResult.OK;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
