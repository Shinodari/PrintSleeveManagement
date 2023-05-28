using PrintSleeveManagement.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class PrintSleeve : BasePrintSleeve
    {
        List<ExpireDate> expiredDateList;
        public enum PRINTSLEEVE_FIND_TYPE
        {
            RollNo,
            ReceiptNo,
            ItemNo
        }

        public int RollNo { get; set; }

        public int ReceiptNo { get; set; }

        public string LotNo { get; set; }

        public int RollNoSecondary { get; set; }

        public DateTime ExpiredDate { get; set; }

        public List<ExpireDate> ExpiredDateList
        {
            get { return this.expiredDateList; }
        }

        public string Creator { get; set; }

        public DateTime CreateTime { get; set; }

        public PrintSleeve()
        {
            this.expiredDateList = new List<ExpireDate>();
        }

        public PrintSleeve(int rollNo, string itemNo, string partNo, string lotNo, int quantity, DateTime expiredDate) : this()
        {
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.Quantity = quantity;
            this.ExpiredDate = expiredDate;
        }

        public PrintSleeve(int rollNo, int receiptNo, string itemNo, string partNo, string lotNo, int quantity, DateTime expiredDate) : this()
        {
            this.RollNo = rollNo;
            this.ReceiptNo = receiptNo;
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.Quantity = quantity;
            this.ExpiredDate = expiredDate;
        }

        public bool Create(int rollNo, int receiptNo, string itemNo, string lotNo, int quantity, DateTime expiredDate, Location location)
        {
            this.RollNo = rollNo;
            this.ItemNo = itemNo;
            this.LotNo = lotNo;
            this.Quantity = quantity;
            this.ExpiredDate = expiredDate;

            ExpireDate expireDate = new ExpireDate(rollNo);

            if (find(rollNo, PRINTSLEEVE_FIND_TYPE.RollNo).Count > 0)
            {
                errorString = "This RollNo already, please use another RollNo.";
                return false;
            }

            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }

            string sql = $"INSERT INTO PrintSleeve VALUES ({rollNo}, {receiptNo}, '{itemNo}', '{lotNo}', {quantity}, '{Authentication.Username}', getDate())";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = command;
            bool result;
            if (dataAdapter.InsertCommand.ExecuteNonQuery() == 1)
            {
                if (expireDate.SetFirstExpireDate(expiredDate) && location.PutAway(this))
                {
                    result = true;
                }
                else
                {
                    dataAdapter.Dispose();
                    command.Dispose();
                    sql = $"DELETE FROM PrintSleeve WHERE RollNo = {rollNo}";
                    command = new SqlCommand(sql, cnn);
                    dataAdapter.DeleteCommand = command;
                    if (dataAdapter.DeleteCommand.ExecuteNonQuery() != 1)
                    {
                        errorString = "Database is accident, please contact Adimistrator";
                    }
                    result = false;
                }
            }
            else
            {
                errorString = "Database is accident, please contact Adimistrator";
                result = false;
            }
            
            dataAdapter.Dispose();
            command.Dispose();
            close();
            return result;
        }

        public bool Remove(int rollNo)
        {
            ExpireDate expireDate = new ExpireDate(rollNo);
            if (!expireDate.RemoveExpireDate())
                return false;

            bool result;
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }
            string sql = $"DELETE FROM PrintSleeve WHERE RollNo = '{rollNo}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = command;
            int i = adapter.DeleteCommand.ExecuteNonQuery();
            if (i > 0)
            {
                result = true;
            }
            else
            {
                errorString = "This PrintSleeve can't Remove!\nPlease contact Adimistrator";
                result = false;
            }
            adapter.Dispose();
            command.Dispose();
            close();
            return result;

        }

        private List<PrintSleeve> find(string sql)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            List<PrintSleeve> printSleeve = new List<PrintSleeve>();
            
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                printSleeve.Add(new PrintSleeve(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt32(4), dataReader.GetDateTime(5)));
            }
            dataReader.Close();
            command.Dispose();
            close();
            return printSleeve;
        }

        public List<PrintSleeve> find(int keyword, PRINTSLEEVE_FIND_TYPE printSleeveFindType)
        {
            string sql = @"SELECT PrintSleeve.RollNo, PrintSleeve.ItemNo, Item.PartNo, PrintSleeve.LotNo, PrintSleeve.Quantity, MAX([ExpireDate].[ExpireDate]) AS 'ExpireDate' FROM PrintSleeve 
                            LEFT JOIN Item ON PrintSleeve.ItemNo = Item.ItemNo 
                            LEFT JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo]";
            switch (printSleeveFindType)
            {
                case PRINTSLEEVE_FIND_TYPE.ReceiptNo:
                    sql += "WHERE PrintSleeve.ReceiptNo = '" + keyword + "'";
                    break;
                case PRINTSLEEVE_FIND_TYPE.RollNo:
                    sql += "WHERE PrintSleeve.RollNo = '" + keyword + "'";
                    break;
                case PRINTSLEEVE_FIND_TYPE.ItemNo:
                    sql += "WHERE PrintSleeve.ItemNo = '" + keyword + "'";
                    break;
            }
            sql += "\nGROUP BY PrintSleeve.RollNo, PrintSleeve.ItemNo, Item.PartNo, PrintSleeve.LotNo, PrintSleeve.Quantity";
            return find(sql);
        }

        public List<PrintSleeve> findReceiptNoAndItemNo(int receiptNo, string itemNo)
        {
            string sql = @"SELECT PrintSleeve.RollNo, PrintSleeve.ItemNo, Item.PartNo, PrintSleeve.LotNo, PrintSleeve.Quantity, MAX([ExpireDate].[ExpireDate]) AS 'ExpireDate' FROM PrintSleeve 
                            LEFT JOIN Item ON PrintSleeve.ItemNo = Item.ItemNo 
                            LEFT JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo]";
            sql += "WHERE PrintSleeve.ReceiptNo = '" + receiptNo + "' AND PrintSleeve.ItemNo = '" + itemNo + "'";
            sql += "\nGROUP BY PrintSleeve.RollNo, PrintSleeve.ItemNo, Item.PartNo, PrintSleeve.LotNo, PrintSleeve.Quantity";
            return find(sql);
        }

        public bool hasRollNoSec(int rollNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return true;
            }
            string sql = $"SELECT ISNULL([RollNoSecondary],0) FROM [PrintSleeve] WHERE [RollNo] = '{rollNo}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            bool result = true;
            while (dataReader.Read())
            {
                if (dataReader.GetInt32(0) != 0)
                    result = true;
                else
                    result = false;
            }
            dataReader.Close();
            command.Dispose();
            close();
            return result;
        }
    }
}
