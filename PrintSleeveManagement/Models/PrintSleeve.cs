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
            Roll,
            PO,
            ItemNo,
            POandItemNo
        }

        public PrintSleeve()
        {

        }

        public PrintSleeve(int rollNo, string itemNo, string partNo, string lotNo, DateTime expiredDate)
        {
            this.RollNo = rollNo;
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.ExpiredDate = expiredDate;
        }

        public void create(Receipt receipt, string itemNo, string rollNo, DateTime expiredDate)
        {

        }

        public void create(Receipt receipt, string itemNo, string rollNo, DateTime expiredDate, int quantity)
        {

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
                printSleeve.Add(new PrintSleeve(dataReader.GetInt32(0), dataReader.GetString(2), dataReader.GetString(7), dataReader.GetString(3), dataReader.GetDateTime(5)));
            }
            dataReader.Close();
            command.Dispose();
            close();
            return printSleeve;
        }

        public List<PrintSleeve> find(int wordFind, PRINTSLEEVE_FIND_TYPE printSleeveFindType)
        {
            string sql = "SELECT PrintSleeve.*, Item.PartNo FROM PrintSleeve LEFT JOIN Item ON PrintSleeve.ItemNo = Item.ItemNo ";
            switch (printSleeveFindType)
            {
                case PRINTSLEEVE_FIND_TYPE.PO:
                    sql += "WHERE PrintSleeve.PONo = '" + wordFind + "'";
                    break;
                case PRINTSLEEVE_FIND_TYPE.Roll:
                    sql += "WHERE PrintSleeve.RollNo = '" + wordFind + "'";
                    break;
                case PRINTSLEEVE_FIND_TYPE.ItemNo:
                    sql += "WHERE PrintSleeve.ItemNo = '" + wordFind + "'";
                    break;
                case PRINTSLEEVE_FIND_TYPE.POandItemNo:
                    return null;
                    break;
            }
            return find(sql);
        }

        public List<PrintSleeve> find(int pONo, int itemNo)
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
        
        
    }
}
