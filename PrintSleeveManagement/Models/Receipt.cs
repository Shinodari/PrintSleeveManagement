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
        public Receipt(int poNo)
        {
            this.PONo = poNo;
            PrintSleeve = new List<BasePrintSleeve>();
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
            String sql = "SELECT * FROM Receipt_Item WHERE PONo = '" + this.PONo + "'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PrintSleeve.Add(new BasePrintSleeve(dataReader.GetValue(1).ToString(), dataReader.GetInt32(2)));
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
                foreach (BasePrintSleeve printSleeve in PrintSleeve)
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
        public List<BasePrintSleeve> PrintSleeve { get; }
        public DateTime ReceiptTime { get; set; }
        public string Receiver { get; set; }
    }
}
