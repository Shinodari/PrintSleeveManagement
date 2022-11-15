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
    public partial class PutAwayForm : Form
    {
        Receipt receipt;
        PrintSleeve printSleeve;

        BindingSource bindingSourceReceipt;
        BindingSource bindingSourceAvailable;

        public PutAwayForm()
        {
            InitializeComponent();
        }

        private void PutAwayForm_Load(object sender, EventArgs e)
        {
            setDiplayReceipt(false);
            dateTimePickerExpiredDate.Value = DateTime.Now;
            textBoxPONo.Focus();
        }

        private void setDiplayReceipt(bool alreadyPO)
        {
            if (alreadyPO)
            {
                groupBoxAvailable.Enabled = true;
                groupBoxPrintSleeve.Enabled = true;
                groupBoxLocation.Enabled = true;
                groupBoxStatus.Enabled = true;

                textBoxPONo.Enabled = false;
                buttonPOBrowse.Enabled = false;
                buttonCommit.Enabled = false;
                buttonClear.Enabled = true;
                dataGridViewReceipt.Enabled = true;
            }
            else
            {
                groupBoxAvailable.Enabled = false;
                groupBoxPrintSleeve.Enabled = false;
                groupBoxLocation.Enabled = false;
                groupBoxStatus.Enabled = false;

                textBoxPONo.Enabled = true;
                buttonPOBrowse.Enabled = true;
                buttonCommit.Enabled = true;
                buttonClear.Enabled = false;
                dataGridViewReceipt.Enabled = false;
            }
        }

        private void commitPO()
        {
            setDiplayReceipt(true);

            int pONo = Int32.Parse(textBoxPONo.Text);
            receipt = new Receipt(pONo);
            receipt.getReceipt();
            bindingSourceReceipt = new BindingSource();
            bindingSourceReceipt.DataSource = receipt.ReceiptBasePrintSleeve;
            dataGridViewReceipt.DataSource = bindingSourceReceipt;
            dataGridViewReceipt.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewReceipt.Columns["Available"].DisplayIndex = 3;
            dataGridViewReceipt.Columns["Quantity"].DisplayIndex = 2;
            bindingSourceReceipt.PositionChanged += new EventHandler(rowChanged);

            setPrintSleeveDisplay(0);
            dataGridViewReceipt.Focus();
        }

        private void rowChanged(object sender, System.EventArgs e)
        {
            if (bindingSourceReceipt.Position >=0)
            {
                setPrintSleeveDisplay(bindingSourceReceipt.Position);
            }
            else
            {
                labelPartNo.Text = "";
            }
        }

        private void setPrintSleeveDisplay(int row)
        {
            labelPartNo.Text = dataGridViewReceipt.Rows[row].Cells[3].Value.ToString();
            int iReceived = Int32.Parse(dataGridViewReceipt.Rows[row].Cells[1].Value.ToString());
            int iAvailable = Int32.Parse(dataGridViewReceipt.Rows[row].Cells[0].Value.ToString());

            labelReceived.Text = iReceived.ToString();
            labelAvailable.Text = iAvailable.ToString();

            List <PrintSleeve> listPrintSleeve = new List<PrintSleeve>();
            printSleeve = new PrintSleeve();
            listPrintSleeve = printSleeve.findPONoAndItemNo(receipt.PONo, Int32.Parse(dataGridViewReceipt.Rows[row].Cells[2].Value.ToString()));
            bindingSourceAvailable = new BindingSource();
            bindingSourceAvailable.DataSource = listPrintSleeve;
            dataGridViewAvailable.DataSource = bindingSourceAvailable;
            dataGridViewAvailable.Columns["PONo"].Visible = false;
            dataGridViewAvailable.Columns["RollNoSecondary"].Visible = false;
            dataGridViewAvailable.Columns["ItemNo"].Visible = false;
            dataGridViewAvailable.Columns["PartNo"].Visible = false;

            int iDiff = iReceived - iAvailable;
            if (iDiff == 0)
            {
                labelReceived.BackColor = Color.Lime;
                labelAvailable.BackColor = Color.Lime;

                labelStatus.Text = "This part's OK";
            }
            else if(iDiff < 0)
            {
                labelReceived.BackColor = Color.Red;
                labelAvailable.BackColor = Color.Red;

                labelStatus.Text = "This part's Over!";
            }
            else
            {
                labelReceived.BackColor = SystemColors.Control;
                labelAvailable.BackColor = SystemColors.Control;

                labelStatus.Text = "";
            }
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure is Clear this PO, but you can put away this PO later.!", "Clear confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                textBoxPONo.Text = "";
                bindingSourceReceipt.Clear();
                labelPartNo.Text = "";
                labelReceived.Text = "0";
                labelAvailable.Text = "0";
                labelLocation.Text = "";
                labelStatus.Text = "";
                setDiplayReceipt(false);
            }
        }

        private void buttonPOBrowse_Click(object sender, EventArgs e)
        {
            PODialog pODialog = new PODialog();
            if (pODialog.Show() == DialogResult.OK)
            {
                textBoxPONo.Text = pODialog.PONo.ToString();
                commitPO();
            }
        }

        private void buttonAddPrintSleeve_Click(object sender, EventArgs e)
        {
            string rollNo = "";
            string locationID = "";
            if (InputDialog.InputBox("RollNo", "Please enter RollNo.", ref rollNo) == DialogResult.OK)
            {
                if (InputDialog.InputBox("Location", "Please enter Location", ref locationID) == DialogResult.OK)
                {

                }
            }
        }
    }
}
