using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Balance : Database
    {
        public string Location { get; set; }

        public string ItemNo { get; set; }

        public string PartNo { get; set; }

        public string LotNo { get; set; }

        public int RollNo { get; set; }

        public DateTime ExpiredDate { get; set; }

        public int Quantity { get; set; }

        public int PONo { get; set; }

        public string Creator { get; set; }

        public DateTime CreateTime { get; set; }

        public string Receiver { get; set; }

        public DateTime ReceivedTime { get; set; }

        public List<Balance> BalanceList { get; set; }

        public Balance()
        {
            BalanceList = new List<Balance>();
            getBalance();
        }

        public Balance(string location, 
            string itemNo, 
            string partNo, 
            string lotNo, 
            int rollNo, 
            DateTime expiredDate, 
            int quantity, 
            int pONo, 
            string creator, 
            DateTime createTime, 
            string receiver, 
            DateTime receivedTime)
        {
            this.Location = location;
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.RollNo = rollNo;
            this.ExpiredDate = expiredDate;
            this.Quantity = quantity;
            this.PONo = pONo;
            this.Creator = creator;
            this.CreateTime = createTime;
            this.Receiver = receiver;
            this.ReceivedTime = receivedTime;
        }

        private void getBalance()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            string sql = "SELECT * FROM [PrintSleeve] LEFT JOIN [Receipt] ON [PrintSleeve].[PONo] = [Receipt].[PONo] LEFT JOIN [Transaction] ON [PrintSleeve].[RollNo] = [Transaction].[RollNo] LEFT JOIN [Item] ON [PrintSleeve].[ItemNo] = [Item].[ItemNo]";
            sql += " ORDER BY [LocationID], [PartNo], [ExpireDate], [LotNo]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                BalanceList.Add(new Balance(dataReader.GetString(13),
                    dataReader.GetString(2),
                    dataReader.GetString(17),
                    dataReader.GetString(3),
                    dataReader.GetInt32(0),
                    dataReader.GetDateTime(5),
                    dataReader.GetInt32(4),
                    dataReader.GetInt32(1),
                    dataReader.GetString(7),
                    dataReader.GetDateTime(8),
                    dataReader.GetString(11),
                    dataReader.GetDateTime(10)));
                /*
                this.ItemNo = ;
                this.PartNo = ;
                this.LotNo =;
                this.RollNo = ;
                this.ExpiredDate = ;
                this.Quantity = ;
                this.PONo = ;
                this.Creator = ;
                this.CreateTime = ;
                this.Receiver = ;
                this.ReceivedTime = ;*/
            }
            dataReader.Close();
            command.Dispose();
            close();/**/
        }
    }
}
