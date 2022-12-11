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

        public PreOrder(string itemNo, string partNo, int quantity, int allocate)
        {
            this.ItemNo = itemNo;
            this.partNo = partNo;
            this.Quantity = quantity;
            //this.Allocate = allocate;

            orderAllocate = new List<OrderAllocate>();
        }

        public void getOrderAllocater(string itemNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            string sql = $"SELECT [PrintSleeve].[ExpireDate], [Transaction].[LocationID], [PrintSleeve].[LotNo], SUM([PrintSleeve].[Quantity]) AS Quantity, ISNULL(SUM([PreOrder].[Allocate]),0) AS Allocate FROM [PrintSleeve] INNER JOIN [Transaction] ON [PrintSleeve].[RollNo] = [Transaction].[RollNo] LEFT JOIN [PreOrder] ON [PreOrder].[LocationID] = [Transaction].[LocationID] WHERE [PrintSleeve].[ItemNo] = '{itemNo}' GROUP BY [PrintSleeve].[ExpireDate], [Transaction].[LocationID], [PrintSleeve].[LotNo] HAVING [Transaction].[LocationID] = MAX([Transaction].[LocationID]) ORDER BY [PrintSleeve].[ExpireDate], [PrintSleeve].[LotNo], [Transaction].[LocationID]";
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
