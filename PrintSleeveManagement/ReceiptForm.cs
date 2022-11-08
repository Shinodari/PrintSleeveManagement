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
    public partial class ReceiptForm : Form
    {
        private List<BasePrintSleeve> basePrintSleeveList;
        private BindingSource bindignSource;
        public ReceiptForm()
        {
            InitializeComponent();

            setDisplay(true);

            Item item = new Item();
            List<Item> partNoList = item.getAll();
            if (partNoList == null)
            {
                MessageBox.Show(item.getErrorString());
            }
            listBoxPartNo.DataSource = partNoList;
            listBoxPartNo.DisplayMember = "PartNo";

            basePrintSleeveList = new List<BasePrintSleeve>();
            bindignSource = new BindingSource();
            bindignSource.DataSource = basePrintSleeveList;
            dataGridViewPrintSleeve.DataSource = bindignSource;
            dataGridViewPrintSleeve.Columns["Quantity"].DisplayIndex = 2;
        }

        private void textBoxPartNo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPartNo.Text != "")
            {
                int index = listBoxPartNo.FindString(textBoxPartNo.Text.ToUpper());
                if (index != -1)
                    listBoxPartNo.SetSelected(index, true);
            }
        }
        private void textBoxPONo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                newPO();
            }
        }
        private void newPO()
        {
            setDisplay(false);
            textBoxPartNo.Focus();
        }
        private void setDisplay(bool lockStatus)
        {
            if (lockStatus)
            {
                textBoxPONo.Enabled = true;
                buttonNew.Enabled = true;
                buttonClear.Enabled = false;

                textBoxPartNo.Enabled = false;
                listBoxPartNo.Enabled = false;
                textBoxQuantity.Enabled = false;
                buttonAdd.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;

                dataGridViewPrintSleeve.Enabled = false;
            }
            else
            {
                textBoxPONo.Enabled = false;
                buttonNew.Enabled = false;
                buttonClear.Enabled = true;

                textBoxPartNo.Enabled = true;
                listBoxPartNo.Enabled = true;
                textBoxQuantity.Enabled = true;
                buttonAdd.Enabled = true;
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;

                dataGridViewPrintSleeve.Enabled = true;
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            newPO();
        }

        private void textBoxPartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                listBoxPartNo.Focus();
            }
        }

        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                addPrintSleeve();
            }
        }

        private void addPrintSleeve()
        {
            BasePrintSleeve basePrintSleeve = new BasePrintSleeve();
            if (basePrintSleeve.setItem(listBoxPartNo.GetItemText(listBoxPartNo.SelectedItem)))
            {
                BasePrintSleeve printSleeve = new BasePrintSleeve();
                printSleeve.setItem(listBoxPartNo.GetItemText(listBoxPartNo.SelectedItem));
                printSleeve.Quantity = Int32.Parse(textBoxQuantity.Text);
                bindignSource.Add(printSleeve);
                dataGridViewPrintSleeve.Rows[dataGridViewPrintSleeve.RowCount - 1].Selected = true;///---Not Work, I
                textBoxPartNo.Text = "";
                textBoxPartNo.Focus();
            }
            else
            {
                MessageBox.Show(basePrintSleeve.getErrorString());
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addPrintSleeve();
        }

        private void listBoxPartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBoxQuantity.Text = "200";
                textBoxQuantity.Focus();
            }
        }
    }
}
