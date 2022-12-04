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
            string orderNo = textBoxOrderNo.Text;

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
    }
}
