using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintSleeveManagement.Models
{
    public partial class BalanceForm : Form
    {
        Balance balance;
        BindingSource bindingSourceBalance;

        public BalanceForm()
        {
            InitializeComponent();
            ViewBalance();
        }

        public void ViewBalance()
        {
            bindingSourceBalance = new BindingSource();
            
            balance = new Balance();
            bindingSourceBalance.DataSource = balance.BalanceList;
            dataGridViewBalance.DataSource = bindingSourceBalance;
            /*
            PrintSleeve printSleeve = new PrintSleeve();
            bindingSourceBalance.DataSource = printSleeve.getBalance();
            dataGridViewBalance.DataSource = bindingSourceBalance;/**/
        }

        private void dataGridViewBalance_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            DataGridViewColumn oldColumn = dataGridViewBalance.SortedColumn;
            DataGridViewColumn newColumn = dataGridViewBalance.Columns[columnIndex];
            ListSortDirection direction;
            
            if (oldColumn != null)
            {
                if (oldColumn == newColumn && dataGridViewBalance.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            //dataGridViewBalance.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
            bindingSourceBalance.DataSource = balance.BalanceList.OrderBy(x => x.PartNo).ToList();
            dataGridViewBalance.Refresh();
        }
    }
}
