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
    public partial class LocationDialog : Form
    {
        public string LocationID { get; set; }
        
        Location location;
        BindingSource bindingSource;

        public LocationDialog()
        {
            InitializeComponent();
            
            location = new Location();
            bindingSource = new BindingSource();
            bindingSource.DataSource = location.GetAllLocation();
            dataGridViewLocation.DataSource = bindingSource;
        }

        public new DialogResult Show()
        {
            Text = "Location View";
            return (ShowDialog());
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.LocationID = dataGridViewLocation.CurrentRow.Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
