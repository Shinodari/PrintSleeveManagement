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
            labelResult.BackColor = Color.Empty;
            labelResult.Text = "";
        }

        private void MovePrintSleeve(string rollNo)
        {
            int iRollNo;
            if (!Int32.TryParse(rollNo, out iRollNo))
            {
                labelResult.Text = "Please input is numeric!";
                labelResult.BackColor = Color.Red;
                return;
            }

            PrintSleeve printsleeve = new PrintSleeve(iRollNo);
            if(printsleeve.RollNo == 0)
            {
                labelResult.Text = printsleeve.getErrorString();
                labelResult.BackColor = Color.Red;
                return;
            }
            if(location == null)
            {
                labelResult.Text = "Please select destination location!";
                labelResult.BackColor = Color.Red;
                return;
            }

            string oldLocation = location.Move(printsleeve);
            if (oldLocation == null)
            {
                labelResult.Text = printsleeve.getErrorString();
                labelResult.BackColor = Color.Red;
                return;
            }

            labelResult.Text = $"{printsleeve.ItemNo} {printsleeve.PartNo}\nRollNo.\t\t{rollNo} \nFrom {oldLocation} \nTo {location.LocationID}\nIs Successfuly";
            labelResult.BackColor = Color.Lime;
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
            string strRollNo = null;
            if (InputDialog.InputBox("RollNo", "Please enter RollNo.", ref strRollNo) == DialogResult.Cancel)
            {
                return;
            }
            MovePrintSleeve(strRollNo);            
        }

        private void textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string txt = textBoxInput.Text;
                if (location.IsLocation(txt.ToUpper()))
                {
                    SetLocation(txt.ToUpper());
                }
                else
                {
                    MovePrintSleeve(txt.ToUpper());
                }
                textBoxInput.Text = "";
            }
        }
    }
}
