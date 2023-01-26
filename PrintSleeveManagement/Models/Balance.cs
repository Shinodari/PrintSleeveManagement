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
        public enum DirectionType
        {
            NONE,
            Ascending,
            Descending
        }

        private string sortedColumn;
        private DirectionType directionType;

        public string LocationID { get; set; }

        public string ItemNo { get; set; }

        public string PartNo { get; set; }

        public string LotNo { get; set; }

        public int RollNo { get; set; }

        public DateTime ExpireDate { get; set; }

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
            this.LocationID = location;
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.RollNo = rollNo;
            this.ExpireDate = expiredDate;
            this.Quantity = quantity;
            this.PONo = pONo;
            this.Creator = creator;
            this.CreateTime = createTime;
            this.Receiver = receiver;
            this.ReceivedTime = receivedTime;
        }

        private void getBalance(string order = null, DirectionType directionType = DirectionType.NONE)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            string sql = @"SELECT [Transaction].[LocationID], [PrintSleeve].[ItemNo], [Item].[PartNo], [PrintSleeve].[LotNo], [PrintSleeve].[RollNo], [PrintSleeve].[ExpireDate], [PrintSleeve].[Quantity], [Receipt].[PONo], [PrintSleeve].[Creator], [PrintSleeve].[CreateTime], [Receipt].[Receiver], [Receipt].[ReceivedTime] FROM [PrintSleeve] 
                            LEFT JOIN [Receipt] ON [PrintSleeve].[PONo] = [Receipt].[PONo] 
                            LEFT JOIN [Transaction] ON [PrintSleeve].[RollNo] = [Transaction].[RollNo] 
                            LEFT JOIN [Item] ON [PrintSleeve].[ItemNo] = [Item].[ItemNo]
                            LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
                            WHERE [Ship].[RollNo] IS NULL";
            if (order == null)
            {
                sql += "\nORDER BY [LocationID], [PartNo], [ExpireDate], [LotNo]";
            }
            else
            {
                sql += $"\nORDER BY [{order}] ";
                switch (directionType)
                {
                    case DirectionType.Ascending:
                        sql += "ASC";
                        break;
                    case DirectionType.Descending:
                        sql += "DESC";
                        break;
                }
            }
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                BalanceList.Add(new Balance(dataReader.GetString(0),
                    dataReader.GetString(1),
                    dataReader.GetString(2),
                    dataReader.GetString(3),
                    dataReader.GetInt32(4),
                    dataReader.GetDateTime(5),
                    dataReader.GetInt32(6),
                    dataReader.GetInt32(7),
                    dataReader.GetString(8),
                    dataReader.GetDateTime(9),
                    dataReader.GetString(10),
                    dataReader.GetDateTime(11)));
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

        public void SortList(string order = null, DirectionType directionType = DirectionType.NONE)
        {
            this.sortedColumn = order;
            this.directionType = directionType;
            BalanceList.Clear();
            getBalance(order, directionType);
        }

        public string GetSotedColumn()
        {
            return this.sortedColumn;
        }

        public DirectionType GetDirectionType()
        {
            return this.directionType;
        }
    }
}
