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
            string oldSortedColumn = balance.GetSotedColumn();
            DataGridViewColumn newColumn = dataGridViewBalance.Columns[columnIndex];
            Balance.DirectionType directionType = balance.GetDirectionType();
            Balance.DirectionType direction;
            
            if (oldSortedColumn != null)
            {
                if (oldSortedColumn == newColumn.Name && directionType == Balance.DirectionType.Ascending)
                {
                    direction = Balance.DirectionType.Descending;
                }
                else
                {
                    direction = Balance.DirectionType.Ascending;
                    dataGridViewBalance.Columns[oldSortedColumn].HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = Balance.DirectionType.Ascending;
            }

            //dataGridViewBalance.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == Balance.DirectionType.Ascending ? SortOrder.Ascending : SortOrder.Descending;
            balance.SortList(newColumn.Name, direction);
            dataGridViewBalance.Refresh();
        }
    }
}
