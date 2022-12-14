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
    }
}
