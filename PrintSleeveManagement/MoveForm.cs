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
    public partial class MoveForm : Form
    {
        Location location;
        public MoveForm()
        {
            InitializeComponent();
        }

        private void SetLocation(string strLocation)
        {
            location = new Location(strLocation);
            labelLocation.Text = strLocation;
        }

        private void MovePrintSleeve(int rollNo)
        {
            PrintSleeve printsleeve = new PrintSleeve(rollNo);
            if(printsleeve.RollNo == 0)
            {
                MessageBox.Show(printsleeve.getErrorString());
                return;
            }

        }

        private void buttonSelecteLocation_Click(object sender, EventArgs e)
        {
            LocationDialog locationDialog = new LocationDialog();
            if (locationDialog.Show() == DialogResult.OK)
            {
                SetLocation(locationDialog.LocationID);
            }
        }

        private void buttonSelectePrintSleeve_Click(object sender, EventArgs e)
        {

        }
    }
}
