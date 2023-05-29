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
    public partial class OverviewForm : Form
    {
        BindingSource bindingSourceInProcess;
        BindingSource bindingSourceExpire;
        BindingSource bindingSourcePriorExpired;
        BindingSource bindingSourcePriorExpiredNextMonth;

        public OverviewForm()
        {
            InitializeComponent();
        }

        private void OverviewForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;

            LoadDetail();
        }

        private void OverviewForm_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadDetail()
        {
            Overview overview = new Overview();

            //In Process for Extend
            bindingSourceInProcess = new BindingSource();
            bindingSourceInProcess.DataSource = overview.GetInProcess();
            dataGridViewInProcess.DataSource = bindingSourceInProcess;
            dataGridViewInProcess.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewInProcess.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Expired DataGrid Detail
            bindingSourceExpire = new BindingSource();
            bindingSourceExpire.DataSource = overview.GetExpired();
            dataGridViewExpired.DataSource = bindingSourceExpire;
            dataGridViewExpired.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewExpired.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Prior Expired(less 30 Days) DataGrid Detail
            bindingSourcePriorExpired = new BindingSource();
            bindingSourcePriorExpired.DataSource = overview.GetPriorExpired();
            dataGridViewPriorExpired.DataSource = bindingSourcePriorExpired;
            dataGridViewPriorExpired.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewPriorExpired.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Prior Expired(Next Month) DataGrid Dtail
            bindingSourcePriorExpiredNextMonth = new BindingSource();
            bindingSourcePriorExpiredNextMonth.DataSource = overview.GetPriorExpiredNextMonth();
            dataGridViewPriorExpiredNextMonth.DataSource = bindingSourcePriorExpiredNextMonth;
            dataGridViewPriorExpiredNextMonth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewPriorExpiredNextMonth.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
