using PrintSleeveManagement.Models;
using PrintSleeveManagement.View;
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
    public partial class AdjustDialog : Form
    {
        Overview overview;
        BindingSource bindingSoruce;

        List<int> listRollNo;
        public AdjustDialog(string issueNo)
        {
            InitializeComponent();

            labelIssueNo.Text = issueNo;

            listRollNo = new List<int>();

            overview = new Overview();
            bindingSoruce = new BindingSource();
            bindingSoruce.DataSource = overview.GetLotListByIssueNo(issueNo);
            dataGridViewAjust.DataSource = bindingSoruce;
            dataGridViewAjust.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewAjust.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public new DialogResult Show()
        {
            Text = "Adjust";
            return (ShowDialog());
        }

        private List<int> GetSelectedRollNo()
        {
            List<int> listRollNo = new List<int>();

            foreach(DataGridViewRow row in dataGridViewAjust.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Selecte"].Value);
                if (isSelected)
                {
                    listRollNo.Add(Int32.Parse(row.Cells["RollNo"].Value.ToString()));
                }
            }
            return listRollNo;
        }

        private void buttonExtend_Click(object sender, EventArgs e)
        {
            string date = null;
            if (DateInputDialog.InputBox("Extend Expired Date", "Input Extended Date", ref date) == DialogResult.OK)
            {
                //List<int> listRollNo = GetSelectedRollNo();
                foreach(DataGridViewRow row in dataGridViewAjust.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["Selecte"].Value);
                    if (isSelected)
                    {
                        //row.Cells["ExtendDate"].Value = date;
                        AdjustView data = (AdjustView) row.DataBoundItem;
                        data.ExtendDate = DateTime.Parse(date);
                    }
                }
                dataGridViewAjust.Refresh();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
