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
        List<BasePrintSleeve> basePrintSleeveList;
        public ReceiptForm()
        {
            InitializeComponent();

            Item item = new Item();
            List<Item> partNoList = item.getAll();
            if (partNoList == null)
            {
                MessageBox.Show(item.getErrorString());
            }
            listBoxPartNo.DataSource = partNoList;
            listBoxPartNo.DisplayMember = "PartNo";

            basePrintSleeveList = new List<BasePrintSleeve>();
            dataGridViewPrintSleeve.DataSource = basePrintSleeveList;
            dataGridViewPrintSleeve.Columns["Quantity"].DisplayIndex = 2;
        }

        private void textBoxPartNo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPartNo.Text != "")
            {
                int index = listBoxPartNo.FindString(textBoxPartNo.Text);
                if (index != -1)
                    listBoxPartNo.SetSelected(index, true);
            }
            /*
            if (textBoxPartNo.Text != "")
            {
                for (int i = 0; i < listBoxPartNo.Items.Count; i++)
                {
                    if (listBoxPartNo.Items[i].ToString().ToLower().Contains(textBoxPartNo.Text.ToLower()))
                    {

                    }
                }
            }/**/
        }
    }
}
