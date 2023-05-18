using PrintSleeveManagement.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Receipt : Database
    {

        private List<ReceiptPrintSleeve> receiptPrintSleeveView;

        public List<ReceiptPrintSleeve> ReceiptPrintSleeveView
        {
            get { return receiptPrintSleeveView; }
        }

        public Receipt()
        {

        }

        public Receipt(int poNo)
        {
            this.PONo = poNo;
            ReceiptBasePrintSleeve = new List<ReceiptBasePrintSleeve>(); //This line will delete when PutAwayForm edit datasource
        }
        public Receipt(int poNo, int receiptNo, string invoiceNo) : this(poNo)
        {
            this.ReceiptNo = receiptNo;
            this.InvoiceNo = invoiceNo;
            GetPrintSleeveByReceiptNo();
        }

        public Receipt(int poNo, int receiptNo, string invoiceNo, DateTime receiptTime, string receiver)
        {
            this.PONo = poNo;
            this.ReceiptNo = receiptNo;
            this.InvoiceNo = invoiceNo;
            this.ReceiptTime = receiptTime;
            this.Receiver = receiver;
        }

        public List<Receipt> GetAllPO()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            List<Receipt> allPO = new List<Receipt>();
            string sql = "SELECT TOP 25 * FROM Receipt";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                allPO.Add(new Receipt(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetString(2), dataReader.GetDateTime(3), dataReader.GetString(4)));
            }
            dataReader.Close();
            command.Dispose();
            close();
            return allPO;
        }

        public void getReceipt()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            SqlCommand command;
            SqlDataReader dataReader;
            String sql = "SELECT Receipt_Item.*, Item.PartNo, SUM(PrintSleeve.Quantity) AS Available FROM Item, Receipt_Item LEFT JOIN PrintSleeve\n";
            sql += "ON Receipt_Item.ItemNo = PrintSleeve.ItemNo AND PrintSleeve.PONo = Receipt_Item.PONo\n";
            sql += "WHERE Receipt_Item.ItemNo = Item.ItemNo AND Receipt_Item.PONo = '" + this.PONo + "'\n";
            sql += "GROUP BY Receipt_Item.ItemNo, Receipt_Item.PONo, Receipt_Item.Quantity, Item.PartNo\n";
            sql += "ORDER BY PartNo";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                int available;
                if (string.IsNullOrEmpty(dataReader.GetValue(4).ToString()))
                {
                    available = 0;
                }
                else
                {
                    available = dataReader.GetInt32(4);
                }
                ReceiptBasePrintSleeve.Add(new ReceiptBasePrintSleeve(dataReader.GetValue(1).ToString(), dataReader.GetString(3), dataReader.GetInt32(2), available));
            }                 

            dataReader.Close();
            command.Dispose();
        }
        
        public int receiveAll()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                return -1;
            }
            //Check dupicate PONo
            string sqlPO = $"SELECT * FROM [Receipt] WHERE [ReceiptNo] = '{this.ReceiptNo}'";
            SqlCommand commandPO = new SqlCommand(sqlPO, cnn);
            SqlDataReader dataReaderPO = commandPO.ExecuteReader();
            commandPO.Dispose();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql;
            bool flagFirstValue = true;
            int row = -2;
            bool hasRows = dataReaderPO.HasRows;
            dataReaderPO.Close();
            if (!hasRows)
            {
                sql = $"INSERT INTO Receipt(PONo, ReceiptNo, InvoiceNo, Receiver) VALUES('{this.PONo}', '{this.ReceiptNo}', '{this.InvoiceNo}', '{Authentication.Username}')";
                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
            }            

            if (ReceiptBasePrintSleeve.Count > 0)
            {
                sql = "INSERT INTO Receipt_Item VALUES";
                foreach (BasePrintSleeve printSleeve in ReceiptBasePrintSleeve)
                {
                    if (flagFirstValue)
                    {
                        flagFirstValue = false;
                    }
                    else
                    {
                        sql += ",";
                    }
                    sql += $"({this.ReceiptNo},'{printSleeve.ItemNo}',{printSleeve.Quantity})";
                }

                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = command;
                row = adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                adapter.Dispose();
                close();
            }
            return row;
        }

        public bool RemovePrintSleeve(int rollNo)
        {
            PrintSleeve printSleeve = new PrintSleeve();
            Transaction transaction = new Transaction();

            if (transaction.Remove(rollNo))
            {
                if (!printSleeve.Remove(rollNo))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public int PONo { get; set; }

        public int ReceiptNo { get; set; }

        public string InvoiceNo { get; set; }

        public List<ReceiptBasePrintSleeve> ReceiptBasePrintSleeve { get; }

        public List<PrintSleeve> PrintSleeve { get; set; }

        public DateTime ReceiptTime { get; set; }

        public string Receiver { get; set; }

        private void GetPrintSleeveByReceiptNo()
        {
            Database.CONNECT_RESULT connect_result = connect();

            receiptPrintSleeveView = new List<ReceiptPrintSleeve>();
            string sql = $@"SELECT [Receipt_Item].[ItemNo], [Item].[PartNo], [Receipt_Item].[Quantity] FROM [Receipt_Item] 
                            LEFT JOIN [Item] ON [Item].[ItemNo] = [Receipt_Item].[ItemNo]
                            WHERE [ReceiptNo] = '{this.ReceiptNo}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                receiptPrintSleeveView.Add(new ReceiptPrintSleeve(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetInt32(2)));
            }
            dataReader.Close();
            command.Dispose();
            close();
        }
    }
}
