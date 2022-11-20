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
        public enum PRINTSLEEVE_FIND_TYPE
        {
            RollNo,
            PONo,
            ItemNo
        }

        public PrintSleeve()
        {

        }

        public PrintSleeve(int rollNo, string itemNo, string partNo, string lotNo, int quantity, DateTime expiredDate)
        {
            this.RollNo = rollNo;
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.Quantity = quantity;
            this.ExpiredDate = expiredDate;
        }

        public bool Create(int rollNo, int pONo, string itemNo, string lotNo, int quantity, DateTime expiredDate, Location location)
        {
            this.RollNo = rollNo;
            this.ItemNo = itemNo;
            this.LotNo = lotNo;
            this.Quantity = quantity;
            this.ExpiredDate = expiredDate;

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

            //This SQL support RollNoSecondary if future remove RollNosecondary in PrintSleeveDatabase must modify this sql value------------/
            string sql = $"INSERT INTO PrintSleeve VALUES ({rollNo}, {pONo}, '{itemNo}', '{lotNo}', {quantity}, '{expiredDate}', NULL, '{Authentication.Username}', getDate())";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = command;
            bool result;
            if (dataAdapter.InsertCommand.ExecuteNonQuery() == 1)
            {
                if (location.PutAway(this))
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
            bool result;
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }
            string sql = $"DELETE FROM [Transaction] WHERE RollNo = '{rollNo}'\n";
            sql += $"DELETE FROM PrintSleeve WHERE RollNo = '{rollNo}'";
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
                errorString = "This action Error!\nPlease contact Adimistrator";
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
                printSleeve.Add(new PrintSleeve(dataReader.GetInt32(0), dataReader.GetString(2), dataReader.GetString(7), dataReader.GetString(3), dataReader.GetInt32(4), dataReader.GetDateTime(5)));
            }
            dataReader.Close();
            command.Dispose();
            close();
            return printSleeve;
        }

        public List<PrintSleeve> find(int keyword, PRINTSLEEVE_FIND_TYPE printSleeveFindType)
        {
            string sql = "SELECT PrintSleeve.*, Item.PartNo FROM PrintSleeve LEFT JOIN Item ON PrintSleeve.ItemNo = Item.ItemNo ";
            switch (printSleeveFindType)
            {
                case PRINTSLEEVE_FIND_TYPE.PONo:
                    sql += "WHERE PrintSleeve.PONo = '" + keyword + "'";
                    break;
                case PRINTSLEEVE_FIND_TYPE.RollNo:
                    sql += "WHERE PrintSleeve.RollNo = '" + keyword + "'";
                    break;
                case PRINTSLEEVE_FIND_TYPE.ItemNo:
                    sql += "WHERE PrintSleeve.ItemNo = '" + keyword + "'";
                    break;
            }
            return find(sql);
        }

        public List<PrintSleeve> findPONoAndItemNo(int pONo, string itemNo)
        {
            string sql = "SELECT PrintSleeve.*, Item.PartNo FROM PrintSleeve LEFT JOIN Item ON PrintSleeve.ItemNo = Item.ItemNo ";
            sql += "WHERE PrintSleeve.PONo = '" + pONo + "' AND PrintSleeve.ItemNo = '" + itemNo + "'";
                    
            return find(sql);
        }

        public int RollNo { get; set; }

        public int PONo { get; }

        public string LotNo { get; set; }

        public int RollNoSecondary { get; set; }

        public DateTime ExpiredDate { get; set; }
                
        public string Creator { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
