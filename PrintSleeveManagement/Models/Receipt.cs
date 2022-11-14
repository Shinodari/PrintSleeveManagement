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

        public Receipt()
        {

        }
        public Receipt(int poNo)
        {
            this.PONo = poNo;
            ReceiptBasePrintSleeve = new List<ReceiptBasePrintSleeve>();
        }

        public Receipt(int poNo, DateTime receiptTime, string receiver)
        {
            this.PONo = poNo;
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
                allPO.Add(new Receipt(dataReader.GetInt32(0), dataReader.GetDateTime(1), dataReader.GetString(2)));
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
            sql += "ON Receipt_Item.ItemNo = PrintSleeve.ItemNo\n";
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
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            bool flagFirstValue = true;
            int row = -2;
            string sql = "INSERT INTO Receipt(PONo, Receiver) VALUES(" + this.PONo + ", '" + Authentication.Username + "')";
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = command;
            if (adapter.InsertCommand.ExecuteNonQuery() > 0)
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
                    sql += "(" + this.PONo + ",'" + printSleeve.ItemNo + "'," + printSleeve.Quantity + ")";
                }

                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = command;
                row = adapter.InsertCommand.ExecuteNonQuery();
            }
            command.Dispose();
            close();
            return row;
        }

        public int PONo { get; set; }

        public List<ReceiptBasePrintSleeve> ReceiptBasePrintSleeve { get; }

        public List<PrintSleeve> PrintSleeve { get; set; }

        public DateTime ReceiptTime { get; set; }

        public string Receiver { get; set; }
    }
}
