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
    public partial class ScrapDialog : Form
    {
        public List<int> RollNoList { get; }

        string ItemNo;
        string ExpriedDate;

        Overview overview;
        BindingSource bindingSource;
        public ScrapDialog(string itemNo, string expiredDate)
        {
            InitializeComponent();

            this.ItemNo = itemNo;
            this.ExpriedDate = expiredDate;
            RollNoList = new List<int>();

            Item item = new Item(itemNo);
            labelItemNo.Text = itemNo;
            labelPartNo.Text = item.PartNo;

            overview = new Overview();
            bindingSource = new BindingSource();
            bindingSource.DataSource = overview.GetLotList(itemNo, expiredDate);
            dataGridView.DataSource = bindingSource;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public new DialogResult Show()
        {
            Text = "Scrap";
            return (ShowDialog());
        }

        private void buttonIssue_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Selecte"].Value);
                if (isSelected)
                {
                    RollNoList.Add(Int32.Parse(row.Cells["RollNo"].Value.ToString()));
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
