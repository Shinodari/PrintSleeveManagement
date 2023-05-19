using PrintSleeveManagement.Models;
using PrintSleeveManagement.View;
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
        private Receipt receipt;
        private BindingSource bindignSource;

        bool flagEditMode = false;
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

            receipt = new Receipt(Int32.Parse(textBoxPONo.Text), Int32.Parse(textBoxReceiptNo.Text), textBoxInvoiceNo.Text);
            bindignSource = new BindingSource();
            bindignSource.DataSource = receipt.ReceiptPrintSleeveView;
            dataGridViewPrintSleeve.DataSource = bindignSource;
            dataGridViewPrintSleeve.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            /*
            dataGridViewPrintSleeve.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewPrintSleeve.Columns["Quantity"].DisplayIndex = 3;
            dataGridViewPrintSleeve.Columns["Moved"].Visible = false;*/

            setDisplay(false);
            textBoxPartNo.Focus();
        }
        private void setDisplay(bool lockStatus)
        {
            if (lockStatus)
            {
                textBoxReceiptNo.Enabled = true;
                textBoxPONo.Enabled = true;
                textBoxInvoiceNo.Enabled = true;
                buttonNew.Enabled = true;
                buttonImport.Enabled = true;
                buttonClear.Enabled = false;

                textBoxPartNo.Enabled = false;
                listBoxPartNo.Enabled = false;
                textBoxQuantity.Enabled = false;
                buttonAdd.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                buttonReceiptAll.Enabled = false;

                dataGridViewPrintSleeve.Enabled = false;
            }
            else
            {
                textBoxReceiptNo.Enabled = false;
                textBoxPONo.Enabled = false;
                textBoxInvoiceNo.Enabled = false;
                buttonNew.Enabled = false;
                buttonImport.Enabled = false;
                buttonClear.Enabled = true;

                textBoxPartNo.Enabled = true;
                listBoxPartNo.Enabled = true;
                textBoxQuantity.Enabled = true;
                buttonAdd.Enabled = true;
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;
                buttonReceiptAll.Enabled = true;

                dataGridViewPrintSleeve.Enabled = true;
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            newPO();
        }

        private void textBoxPartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    textBoxQuantity.Focus();
                    break;

            }
        }

        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!flagEditMode)
                {
                    addPrintSleeve();
                }
                else
                {
                    editPrintSleeve();
                }
            }
        }

        private void addPrintSleeve()
        {
            ReceiptBasePrintSleeve basePrintSleeve = new ReceiptBasePrintSleeve(); //This may must delete
            if (textBoxQuantity.Text == "")
            {
                MessageBox.Show("Please enter the Quantity!");
                return;
            }

            ReceiptPrintSleeve receiptPrintSleeveView = new ReceiptPrintSleeve(listBoxPartNo.GetItemText(listBoxPartNo.SelectedItem), Int32.Parse(textBoxQuantity.Text));


            /*
            if (basePrintSleeve.setItemNo(listBoxPartNo.GetItemText(listBoxPartNo.SelectedItem)))
            {
                if (receipt.ReceiptBasePrintSleeve.Exists(x => x.ItemNo == basePrintSleeve.ItemNo))
                {
                    MessageBox.Show(basePrintSleeve.PartNo + " is Already!\nPlease another part or use edit mode");
                }
                else
                {
                    basePrintSleeve.Quantity = Int32.Parse(textBoxQuantity.Text);
                    bindignSource.Add(basePrintSleeve);
                    dataGridViewPrintSleeve.CurrentCell = dataGridViewPrintSleeve[2,dataGridViewPrintSleeve.RowCount -1];
                }
                textBoxPartNo.Text = "";
                textBoxQuantity.Text = "200";
                textBoxPartNo.Focus();
            }/
            else
            {
                MessageBox.Show(basePrintSleeve.getErrorString());
            }**/
        }

        private void editPrintSleeve()
        {
            dataGridViewPrintSleeve.CurrentRow.Cells[0].Value = textBoxQuantity.Text;
            setEditMode(false);
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

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            textBoxPartNo.Text = dataGridViewPrintSleeve.CurrentRow.Cells[2].Value.ToString();
            textBoxQuantity.Text = dataGridViewPrintSleeve.CurrentRow.Cells[0].Value.ToString();

            setEditMode(true);
        }
        private void buttonDone_Click(object sender, EventArgs e)
        {
            editPrintSleeve();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            setEditMode(false);
        }

        private void setEditMode(bool editMode)
        {
            if (editMode)
            {
                flagEditMode = true;

                buttonClear.Enabled = false;

                textBoxPartNo.Enabled = false;
                listBoxPartNo.Enabled = false;
                buttonAdd.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                buttonReceiptAll.Enabled = false;

                buttonDone.Visible = true;
                buttonCancel.Visible = true;

                dataGridViewPrintSleeve.Enabled = false;

                textBoxQuantity.Focus();
            }
            else
            {
                flagEditMode = false;

                buttonClear.Enabled = true;

                textBoxPartNo.Enabled = true;
                listBoxPartNo.Enabled = true;
                buttonAdd.Enabled = true;
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;
                buttonReceiptAll.Enabled = true;

                buttonDone.Visible = false;
                buttonCancel.Visible = false;

                dataGridViewPrintSleeve.Enabled = true;

                textBoxPartNo.Text = "";
                textBoxQuantity.Text = "200";
                textBoxPartNo.Focus();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to DELETE?", "Delete Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridViewPrintSleeve.Rows.RemoveAt(dataGridViewPrintSleeve.CurrentCell.RowIndex);
            }            
        }

        private void textBoxPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    listBoxPartNo.SelectedIndex -= 1;
                    e.Handled = true;
                    break;
                case Keys.Down:
                    listBoxPartNo.SelectedIndex += 1;
                    e.Handled = true;
                    break;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You'll lost All Data\nAre you sure to Clear this PO?", "Clear PO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bindignSource.Clear();
                setDisplay(true);
                textBoxPONo.Text = "";
                textBoxPONo.Focus();
            }
        }

        private void buttonReceiptAll_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrintSleeve.RowCount < 1)
            {
                MessageBox.Show("Please add PrintSleeve into this PO!");
                return;
            }
            int result =receipt.receiveAll();
            if (result >= 0)
            {
                MessageBox.Show("Received " + result + " Rows of PO " + receipt.PONo + " is Successfully");
                textBoxPONo.Text = "";
                textBoxPartNo.Text = "";
                textBoxQuantity.Text = "200";
                bindignSource.Clear();
                setDisplay(true);
            }
            else
            {
                MessageBox.Show("Can't connect the database!\nPlease contact Administrator");
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "XLS files (*.xls)|*.xls";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Somting
                }
            }
        }
    }
}
