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
        Order order;
        BindingSource bindingSourceOrder;

        public PickForm()
        {
            InitializeComponent();

            order = new Order();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            commitOrder();
        }

        private void commitOrder()
        {
            order.OrderNo = Int32.Parse(textBoxOrderNo.Text);
            if (order.IsOrder)
            {

            }
            
            bindingSourceOrder = new BindingSource();
            bindingSourceOrder.DataSource = order.Allocation;
            dataGridViewOrder.DataSource = bindingSourceOrder;
            dataGridViewOrder.Columns["Quantity"].DisplayIndex = 1;
            dataGridViewOrder.Columns["PartNo"].ReadOnly = true;
            dataGridViewOrder.Columns["ItemNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewOrder.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewOrder.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DisplayAllocate(string itemNo)
        {
            PrintSleeve printSleeve = new PrintSleeve();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = printSleeve.getLocation(itemNo);
            dataGridViewAllocate.DataSource = bindingSource;
        }

        private void dataGridViewOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                Item item = new Item();
                if (item.setPartNo(dataGridViewOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    dataGridViewOrder.Rows[e.RowIndex].Cells[2].Value = item.PartNo;
                    DisplayAllocate(item.ItemNo);
                }
                else
                {
                    MessageBox.Show("ItemNo incorrect!");
                    dataGridViewOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                }
                
            }
        }

        private void buttonAllocate_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewAllocate_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rollNo = (int) dataGridViewAllocate.Rows[e.RowIndex].Cells[4].Value;
            PrintSleeve printSleeve = new PrintSleeve();
            List<PrintSleeve> printSleeveList = printSleeve.find(rollNo, PrintSleeve.PRINTSLEEVE_FIND_TYPE.RollNo);
            if ((bool)dataGridViewAllocate.Rows[e.RowIndex].Cells[0].Value)
            {
                if (!order.IsAllocate(rollNo))
                {
                    order.PrintSleeve.Add(printSleeveList[0]);
                }
                else {
                    MessageBox.Show("Error 501");
                }
            }
            else
            {
                if (order.IsAllocate(rollNo))
                {
                    for (int i = 0; i < order.PrintSleeve.Count; i++)
                    {
                        if (order.PrintSleeve[i].RollNo == rollNo)
                        {
                            order.PrintSleeve.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error 502");
                }
            }
        }
    }
}
