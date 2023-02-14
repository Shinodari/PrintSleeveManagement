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
    public partial class BrowseDialog : Form
    {
        public string Result
        {
            get { return result; }
        }

        string result;
        
        string title;
        int returnCollumnIndex;
        BindingSource bindingSource;

        public BrowseDialog(Object browseDataSource, string title, int returnCollumnIndex)
        {
            InitializeComponent();

            this.title = title;
            this.returnCollumnIndex = returnCollumnIndex;
            bindingSource = new BindingSource();
            bindingSource.DataSource = browseDataSource;
            dataGridViewBrowse.DataSource = bindingSource;
        }

        public new DialogResult Show()
        {
            Text = this.title;
            return (ShowDialog());
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.result = dataGridViewBrowse.CurrentRow.Cells[this.returnCollumnIndex].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
