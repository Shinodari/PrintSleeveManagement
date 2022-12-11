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
    public partial class StageForm : Form
    {
        Stage stage;

        public StageForm()
        {
            InitializeComponent();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            string orderNo = textBoxOrderNo.Text;
            stage = new Stage(Int32.Parse(orderNo));

            BindingSource bindingSourceOrder = new BindingSource();
            bindingSourceOrder.DataSource = stage.StageViewList;
            dataGridViewOrder.DataSource = bindingSourceOrder;
            dataGridViewOrder.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            BindingSource bindingSourceStage = new BindingSource();
            bindingSourceStage.DataSource = stage.PrintSleeveList;
            dataGridViewStage.DataSource = bindingSourceStage;
            dataGridViewStage.Columns["PONo"].Visible = false;
            dataGridViewStage.Columns["RollNoSecondary"].Visible = false;
            dataGridViewStage.Columns["Creator"].Visible = false;
            dataGridViewStage.Columns["CreateTime"].Visible = false;
        }
    }
}
