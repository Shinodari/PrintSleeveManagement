using PrintSleeveManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintSleeveManagement
{
    public partial class PutAwayForm : Form
    {
        public delegate void DataReceiveCallback(string data);

        Receipt receipt;
        PrintSleeve printSleeve;
        Location location;
        Device device;

        BindingSource bindingSourceReceipt;
        BindingSource bindingSourceAvailable;

        public PutAwayForm()
        {
            InitializeComponent();

            device = new Device();
            location = new Location();
        }

        public PutAwayForm(Device device) : this()
        {            
            this.device = device;
        }

        private void PutAwayForm_Load(object sender, EventArgs e)
        {            
            setDiplayReceipt(false);
            dateTimePickerExpiredDate.Value = DateTime.Now;
            textBoxPONo.Focus();

            if (Device.InputMode == Device.DEVICE_INPUT_MODE.SERIAL_PORT)
            {
                device.serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }
            else
            {
                textBoxInputData.Enabled = true;
            }
        }

        private void DataCallback(string data)
        {
            if (this.textBoxInputData.InvokeRequired)
            {
                DataReceiveCallback d = new DataReceiveCallback(DataCallback);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                this.textBoxInputData.Text = data;
            }
        }
        
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            DataCallback(indata);
        }/**/

        private void setDiplayReceipt(bool alreadyPO)
        {
            if (alreadyPO)
            {
                groupBoxAvailable.Enabled = true;
                groupBoxPrintSleeve.Enabled = true;
                groupBoxLocation.Enabled = true;
                groupBoxStatus.Enabled = true;

                textBoxPONo.Enabled = false;
                buttonPOBrowse.Enabled = false;
                buttonCommit.Enabled = false;
                buttonClear.Enabled = true;
                dataGridViewReceipt.Enabled = true;
            }
            else
            {
                groupBoxAvailable.Enabled = false;
                groupBoxPrintSleeve.Enabled = false;
                groupBoxLocation.Enabled = false;
                groupBoxStatus.Enabled = false;

                textBoxPONo.Enabled = true;
                buttonPOBrowse.Enabled = true;
                buttonCommit.Enabled = true;
                buttonClear.Enabled = false;
                dataGridViewReceipt.Enabled = false;
            }
        }

        private void updateReceipt()
        {
            int cRow = bindingSourceReceipt.Position;
            bindingSourceReceipt.Clear();
            receipt.getReceipt();
            bindingSourceReceipt.ResetBindings(false);
            if (cRow == 0)
            {
                setPrintSleeveDisplay(0);
            }
            else
            {
                bindingSourceReceipt.Position = cRow;
            }
            checkResult();
        }

        private void commitPO()
        {
            setDiplayReceipt(true);

            if (string.IsNullOrWhiteSpace(textBoxPONo.Text) || string.IsNullOrEmpty(textBoxPONo.Text))
            {
                return;
            }

            int pONo = Int32.Parse(textBoxPONo.Text);
            receipt = new Receipt(pONo);
            receipt.getReceipt();
            bindingSourceReceipt = new BindingSource();
            bindingSourceReceipt.DataSource = receipt.ReceiptBasePrintSleeve;
            dataGridViewReceipt.DataSource = bindingSourceReceipt;
            dataGridViewReceipt.Columns["PartNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewReceipt.Columns["Moved"].DisplayIndex = 3;
            dataGridViewReceipt.Columns["Quantity"].DisplayIndex = 2;
            bindingSourceReceipt.PositionChanged += new EventHandler(rowChanged);
                        
            setPrintSleeveDisplay(0);
            dataGridViewReceipt.Focus();
        }

        private void rowChanged(object sender, System.EventArgs e)
        {
            if (bindingSourceReceipt.Position >=0)
            {
                setPrintSleeveDisplay(bindingSourceReceipt.Position);
            }
            else
            {
                labelPartNo.Text = "";
            }
        }

        private void updatePrintSleeveDisplay()
        {
            int iReceived = Int32.Parse(labelReceived.Text);
            int iAvailable = Int32.Parse(labelAvailable.Text);
            int iDiff = iReceived - iAvailable;
            if (iDiff == 0)
            {
                labelReceived.BackColor = Color.Lime;
                labelAvailable.BackColor = Color.Lime;

                labelStatus.Text = "This part's OK";
            }
            else if (iDiff < 0)
            {
                labelReceived.BackColor = Color.Red;
                labelAvailable.BackColor = Color.Red;

                labelStatus.Text = "This part's Over!";
            }
            else
            {
                labelReceived.BackColor = SystemColors.Control;
                labelAvailable.BackColor = SystemColors.Control;

                labelStatus.Text = "";
            }
        }

        private void setPrintSleeveDisplay(int row)
        {
            if (dataGridViewReceipt.RowCount < 1)
            {
                return;
            }
            labelPartNo.Text = dataGridViewReceipt.Rows[row].Cells[3].Value.ToString();
            int iReceived = Int32.Parse(dataGridViewReceipt.Rows[row].Cells[1].Value.ToString());
            int iAvailable = Int32.Parse(dataGridViewReceipt.Rows[row].Cells[0].Value.ToString());

            labelReceived.Text = iReceived.ToString();
            labelAvailable.Text = iAvailable.ToString();

            List <PrintSleeve> listPrintSleeve = new List<PrintSleeve>();
            printSleeve = new PrintSleeve();
            printSleeve.ItemNo = dataGridViewReceipt.Rows[row].Cells[2].Value.ToString();
            listPrintSleeve = printSleeve.findPONoAndItemNo(receipt.PONo, printSleeve.ItemNo);
            bindingSourceAvailable = new BindingSource();
            bindingSourceAvailable.DataSource = listPrintSleeve;
            dataGridViewAvailable.DataSource = bindingSourceAvailable;
            dataGridViewAvailable.Columns["PONo"].Visible = false;
            dataGridViewAvailable.Columns["RollNoSecondary"].Visible = false;
            dataGridViewAvailable.Columns["ItemNo"].Visible = false;
            dataGridViewAvailable.Columns["PartNo"].Visible = false;
            dataGridViewAvailable.Columns["Creator"].Visible = false;
            dataGridViewAvailable.Columns["CreateTime"].Visible = false;

            updatePrintSleeveDisplay();
            checkResult();
        }

        private void textBoxPONo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                commitPO();
            }
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {
            commitPO();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure is Clear this PO, but you can put away this PO later.!", "Clear confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                textBoxPONo.Text = "";
                bindingSourceReceipt.Clear();
                labelPartNo.Text = "";
                labelReceived.Text = "0";
                labelAvailable.Text = "0";
                labelLocation.Text = "";
                labelStatus.Text = "";
                setDiplayReceipt(false);
            }
        }

        private void buttonPOBrowse_Click(object sender, EventArgs e)
        {
            PODialog pODialog = new PODialog();
            if (pODialog.Show() == DialogResult.OK)
            {
                textBoxPONo.Text = pODialog.PONo.ToString();
                commitPO();
            }
        }

        private void buttonAddPrintSleeve_Click(object sender, EventArgs e)
        {
            addPrintSleeve();
        }

        private void buttonSelectLocation_Click(object sender, EventArgs e)
        {
            LocationDialog locationDialog = new LocationDialog();
            if (locationDialog.Show() == DialogResult.OK)
            {
                getLocation(locationDialog.LocationID);
            }
        }

        private void getLocation(string strLocation)
        {
            location = new Location(strLocation);
            labelLocation.Text = location.LocationID;
        }

        private void addPrintSleeve(string rollNo = null)
        {
            if (DateTime.Compare(dateTimePickerExpiredDate.Value, DateTime.Now) <= 0)
            {
                if (MessageBox.Show("PrintSleeve is Expied!\nAre you sure to put away?", "Expired!", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    dateTimePickerExpiredDate.Focus();
                    return;
                }
            }
            else if (DateTime.Compare(dateTimePickerExpiredDate.Value, DateTime.Now.AddMonths(1)) <= 0)
            {
                if (MessageBox.Show("PrintSleeve will Expired in 1 Month!\nAre you sure to put away?", "Expired!", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    dateTimePickerExpiredDate.Focus();
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(textBoxLotNo.Text))
            {
                MessageBox.Show("Please enter LotNo!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(textBoxQuantity.Text))
            {
                MessageBox.Show("Please enter Quantity!");
                return;
            }

            if (location == null || location.LocationID == null)
            {
                MessageBox.Show("Please specify Location!");
                return;
            }

            PrintSleeve printSleeve = new PrintSleeve();
            if (string.IsNullOrEmpty(rollNo)) {
                if (InputDialog.InputBox("RollNo", "Please enter RollNo.", ref rollNo) == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (!printSleeve.Create(Int32.Parse(rollNo), receipt.PONo,
                            this.printSleeve.ItemNo, textBoxLotNo.Text,
                            Int32.Parse(textBoxQuantity.Text),
                            dateTimePickerExpiredDate.Value,
                            location))
            {
                MessageBox.Show(printSleeve.getErrorString());
            }
            updateReceipt();
        }

        private void checkResult()
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridViewReceipt.Rows)
            {
                int iReceived = Int32.Parse(row.Cells[1].Value.ToString());
                int iAvailable = Int32.Parse(row.Cells[0].Value.ToString());
                if (iReceived == iAvailable){
                    row.DefaultCellStyle.BackColor = Color.Lime;
                    count++;
                }
                else if (iReceived < iAvailable)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }
            }
            if (dataGridViewReceipt.RowCount == count)
            {
                labelStatus.Text = "Complete";
                labelStatus.BackColor = Color.Lime;
            }
            else
            {
                labelStatus.Text = "";
                labelStatus.BackColor = SystemColors.Control;
            }/***/
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            PrintSleeve printSleeve = new PrintSleeve();
            Transaction transaction = new Transaction();

            int rollNo = (Int32) dataGridViewAvailable.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Ara you Sure to Delete RollNo " + rollNo.ToString(), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (receipt.RemovePrintSleeve(rollNo))
                {
                    updateReceipt();
                }
                else
                {
                    MessageBox.Show(printSleeve.getErrorString());
                }
            }
        }

        private void processInputData(string data)
        {
            if (location.IsLocation(data))
            {
                getLocation(data);
            }
            else
            {
                addPrintSleeve(data);
            }
        }

        private void textBoxInputData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string txt = textBoxInputData.Text;
                processInputData(txt.ToUpper());
                textBoxInputData.Text = "";
                /*
                for (int i = 0; i < txt.Length; i++)
                {
                    byte b = Convert.ToByte(txt[i]);
                    if (b.ToString() == "13")
                    {
                        txt = txt.Substring(0, txt.Length - 1);
                        processInputData(txt);
                        textBoxInputData.Text = "";
                    }
                }*/
            }
        }
    }
}
