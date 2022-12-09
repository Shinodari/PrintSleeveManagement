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
            bindingSourceOrder = new BindingSource();
            order.OrderNo = Int32.Parse(textBoxOrderNo.Text);
            if (order.IsOrder)
            {
                
            }
            else
            {
                order.CreateOrder();
            }
            
            bindingSourceOrder.DataSource = order.PreOrder;
            dataGridViewOrder.DataSource = bindingSourceOrder;
            /*
            dataGridViewOrder.Columns["Quantity"].DisplayIndex = 1;
            dataGridViewOrder.Columns["PartNo"].ReadOnly = true;
            dataGridViewOrder.Columns["ItemNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewOrder.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewOrder.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;*/
        }

        private void DisplayAllocate(string itemNo)
        {
            BindingSource bindingSource = new BindingSource();
            order.PreOrder[order.PreOrder.Count - 1].getOrderAllocater(itemNo);
            bindingSource.DataSource = order.PreOrder[order.PreOrder.Count - 1].OrderAllocate;
            dataGridViewAllocate.DataSource = bindingSource;
        }

        private void dataGridViewOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Item item = new Item();
                if (item.setPartNo(dataGridViewOrder.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
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
            int countAllocate = order.Allocate();
            MessageBox.Show($"OrderNo {order.OrderNo} allocate {countAllocate} Rolls");
        }

        private void dataGridViewAllocate_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {

        }
    }
}
