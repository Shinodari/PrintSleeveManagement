using PrintSleeveManagement.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class PreOrder : Database
    {
        private int orderNo;
        private string itemNo;
        private string partNo;
        private List<OrderAllocate> orderAllocate;

        public string ItemNo {
            get { return itemNo; }
            set
            {
                orderAllocate = new List<OrderAllocate>();
                itemNo = value;
                Item item = new Item();
                item.setPartNo(itemNo);
                partNo = item.PartNo;
                this.PullOrderAllocater(itemNo);
            }
        }

        public string PartNo {
            get { return partNo; }
        }

        public int Quantity { get; set; }

        public int Allocate
        {
            get
            {
                if (orderAllocate != null)
                {
                    int total = 0;
                    foreach (OrderAllocate oac in orderAllocate)
                    {
                        total += oac.Allocate;
                    }
                    return total;
                }
                else { return 0; }
            }
        }

        public List<OrderAllocate> OrderAllocate
        {
            get { return orderAllocate; }
        }

        public PreOrder()
        {

        }

        public PreOrder(int orderNo, string itemNo, string partNo, int quantity, int allocate)
        {
            this.orderNo = orderNo;
            this.ItemNo = itemNo;
            this.partNo = partNo;
            this.Quantity = quantity;
            //this.Allocate = allocate;

            orderAllocate = new List<OrderAllocate>();
            PullOrderAllocater(itemNo);
        }

        public void PullOrderAllocater(string itemNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            string sql = $@"SELECT [PrintSleeve].[ExpireDate], [Transaction].[LocationID], [PrintSleeve].[LotNo], 
                            SUM([PrintSleeve].[Quantity]) AS Quantity, 
                            (SELECT ISNULL(SUM([Allocate]),0) FROM [Allocate] 
	                            WHERE [OrderNo] = '{this.orderNo}' 
	                            AND [ItemNo] = [PrintSleeve].[ItemNo] 
	                            AND [LocationID] = [Transaction].[LocationID] 
	                            AND [LotNo] = [PrintSleeve].[LotNo]) AS Allocate
                            FROM [PrintSleeve] 
                            INNER JOIN [Transaction] ON [PrintSleeve].[RollNo] = [Transaction].[RollNo] 
                            LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
                            WHERE [PrintSleeve].[ItemNo] = '{itemNo}' AND [Ship].[RollNo] IS NULL
                            GROUP BY [PrintSleeve].[ExpireDate], [Transaction].[LocationID], [PrintSleeve].[LotNo], [PrintSleeve].[ItemNo] , [Ship].[RollNo]
                            HAVING [Transaction].[LocationID] = MAX([Transaction].[LocationID]) 
                            ORDER BY [PrintSleeve].[ExpireDate], [PrintSleeve].[LotNo], [Transaction].[LocationID]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            List<PreOrder> preOrder = new List<PreOrder>();
            while (dataReader.Read())
            {
                orderAllocate.Add(new OrderAllocate(dataReader.GetDateTime(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetInt32(4)));
            }

            dataReader.Close();
            command.Dispose();
            close();
        }
    }
}
