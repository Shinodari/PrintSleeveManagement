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
    public partial class PickForm : Form
    {
        Pick pick;
        BindingSource bindingSourceOrder;
        BindingSource bindingSourcePick;

        public PickForm()
        {
            InitializeComponent();

            bindingSourceOrder = new BindingSource();
            bindingSourcePick = new BindingSource();
        }

        private void InputRollNo(int rollNo)
        {
            if (!pick.AddPrintSleeve(rollNo))
                MessageBox.Show(pick.getErrorString());
            
            bindingSourcePick.ResetBindings(false);
        }

        private void InputRollNo(int rollNo, int rollNoSec)
        {
            if (!pick.AddPrintSleeve(rollNo, rollNoSec))
            {
                if (pick.getErrorString() == "DifferantLocation")
                {
                    string locationID = null;
                    if (InputDialog.InputBox("Location", "Please enter Location.", ref locationID) == DialogResult.Cancel)
                        return;
                    InputRollNo(rollNo, rollNoSec, locationID);
                }
                else
                    MessageBox.Show(pick.getErrorString());
            }
            else
            {
                bindingSourcePick.ResetBindings(false);
            }
        }

        private void InputRollNo(int rollNo, int rollNoSec, string locationID)
        {
            if (!pick.AddPrintSleeve(rollNo, rollNoSec, locationID))
                MessageBox.Show(pick.getErrorString());

            bindingSourcePick.ResetBindings(false);
        }

        private void checkStageColor()
        {
            for (int i = 0; i < dataGridViewOrder.RowCount; i++)
            {
                int allocate = (int)dataGridViewOrder.Rows[i].Cells["Allocate"].Value;
                int stage = (int)dataGridViewOrder.Rows[i].Cells["Stage"].Value;
                if (allocate == stage)
                    dataGridViewOrder.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                else if (allocate < stage)
                    dataGridViewOrder.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                else
                    dataGridViewOrder.Rows[i].DefaultCellStyle.BackColor = SystemColors.Window;
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            string orderNo = textBoxOrderNo.Text;
            pick = new Pick(Int32.Parse(orderNo));
                        
            bindingSourceOrder.DataSource = pick.PickViewList;
            bindingSourceOrder.ListChanged += BindingSourceOrder_ListChanged;
            dataGridViewOrder.DataSource = bindingSourceOrder;
            dataGridViewOrder.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewOrder.CellValueChanged += DataGridViewOrder_CellValueChanged;

            bindingSourcePick.DataSource = pick.StageList;
            bindingSourcePick.ListChanged += BindingSourcePick_ListChanged;
            dataGridViewPick.DataSource = bindingSourcePick;

            checkStageColor();
            dataGridViewOrder.ClearSelection();
        }

        private void BindingSourceOrder_ListChanged(object sender, ListChangedEventArgs e)
        {
            //MessageBox.Show("OrderListChanged");
        }

        private void BindingSourcePick_ListChanged(object sender, ListChangedEventArgs e)
        {
            //MessageBox.Show("PickListChanged");
            pick.UpdateStage();
            dataGridViewOrder.Refresh();
            checkStageColor();
        }

        private void DataGridViewOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("OrderDataChange");
        }

        private void buttonStage_Click(object sender, EventArgs e)
        {
            int rs = pick.Stage();
            if (rs > 0)
                MessageBox.Show($"Pick {rs} Rolls is Succesfuly");
            else
                MessageBox.Show("Pick is Error!\nPlease try agian");
        }

        private void buttonInputManually_Click(object sender, EventArgs e)
        {
            string strRollNo = null;
            if (InputDialog.InputBox("RollNo", "Please enter RollNo.", ref strRollNo) == DialogResult.Cancel)
            {
                return;
            }

            if (!string.IsNullOrEmpty(strRollNo) || !string.IsNullOrWhiteSpace(strRollNo))
            {
                int rollNo;
                if (Int32.TryParse(strRollNo, out rollNo))
                {
                    PrintSleeve printSleeve = new PrintSleeve();
                    if (!printSleeve.hasRollNoSec(rollNo))
                        InputRollNo(rollNo);
                    else
                    {
                        string strRollNoSec = null;
                        if (InputDialog.InputBox("RollNoSec", "Please enter RollNoSecondary.", ref strRollNoSec) == DialogResult.Cancel)
                        {
                            MessageBox.Show("Stage PrintSleeve is Fail!\nPlease try again!");
                            return;
                        }

                        if (!string.IsNullOrEmpty(strRollNoSec) || !string.IsNullOrWhiteSpace(strRollNoSec))
                        {
                            int rollNoSec;
                            if (Int32.TryParse(strRollNoSec, out rollNoSec))
                            {
                                InputRollNo(rollNo, rollNoSec);                                
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("RollNo isn't Numeric!");
                }
            }
        }
    }
}
