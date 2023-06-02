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

        string issueNo;
        List<int> listRollNo;
        public AdjustDialog(string issueNo)
        {
            InitializeComponent();

            labelIssueNo.Text = issueNo;

            this.issueNo = issueNo;
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

        private void buttonExtend_Click(object sender, EventArgs e)
        {
            string date = null;
            if (DateInputDialog.InputBox("Extend Expired Date", "Input Extended Date", ref date) == DialogResult.OK)
            {
                foreach(DataGridViewRow row in dataGridViewAjust.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["Selecte"].Value);
                    if (isSelected)
                    {
                        AdjustView data = (AdjustView) row.DataBoundItem;
                        data.SetExtendDate(DateTime.Parse(date));
                        data.Selecte = false;
                    }
                }
                dataGridViewAjust.Refresh();
            }
        }
        private void buttonScrap_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridViewAjust.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Selecte"].Value);
                if (isSelected)
                {
                    AdjustView data = (AdjustView)row.DataBoundItem;
                    data.SetScrap();
                    data.Selecte = false;
                }
            }
            dataGridViewAjust.Refresh();
        }
        private void buttonAdjust_Click(object sender, EventArgs e)
        {
            /*----- For Extended Date or Scrap Date set to action date in current.  -----*/
            /*----- For Future will change to sheet date as Inspection section assign-----*/
            foreach (DataGridViewRow row in dataGridViewAjust.Rows)
            {
                int rollNo = (int) row.Cells["RollNo"].Value;
                bool scrap = (bool) row.Cells["Scrap"].Value;
                DateTime newExpiredDate = (DateTime)row.Cells["NewExpiredDate"].Value;

                ExpireDate exprieDate = new ExpireDate(rollNo);
                DateTime extendDate = DateTime.Now;
                if (scrap == false && newExpiredDate == DateTime.MinValue)
                {
                    MessageBox.Show($"RollNo.{rollNo} not adjust new expired date or scrap!\nPlease check again.");
                    return;
                }
                else if (scrap == true)
                {
                    exprieDate.Scrap(extendDate);
                }
                else if (newExpiredDate != DateTime.MinValue)
                {
                    exprieDate.ExtendExpiredDate(newExpiredDate, extendDate);
                }
                else
                {
                    MessageBox.Show($"RollNo.{rollNo} adjugst new expired date and scrap!\nPlease check agian.");
                    return;
                }
            }
            MessageBox.Show($"IssueNo.{this.issueNo} adjust is successfuly");
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridViewAjust_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewAjust.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
