using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Stage : Database
    {
        Order order;

        private static List<Order> orderWithStageStatus;

        public Stage(int orderNo)
        {
            order = new Order();
            order.OrderNo = orderNo;
        }

        public List<Order> OrderWithStageStatus
        {
            get { return orderWithStageStatus; }
        }

        private List<Order> getOrderWithStageStatus()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            string sql = $"SELECT [Order].[OrderNo], SUM([Order_Item].[Quantity]), (SELECT SUM([PrintSleeve].[Quantity]) FROM [PrintSleeve], [Stage] WHERE[PrintSleeve].[RollNo] = [Stage].[RollNo] AND [Stage].[OrderNo] = '{order.OrderNo}') FROM[Order] LEFT JOIN[Order_Item] ON[Order].[OrderNo] = [Order_Item].[OrderNo] WHERE[Order].[OrderNo] = '{order.OrderNo}' GROUP BY[Order].[OrderNo]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            

            dataReader.Close();
            command.Dispose();
            close();
        }
    }
}
