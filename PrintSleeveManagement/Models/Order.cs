using PrintSleeveManagement.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Order : Database
    {
        private int orderNo;
        private List<BasePrintSleeve> allocation;
        private List<PreOrder> preOrder;
        private bool isOrder;

        public int OrderNo
        {
            get { return orderNo; }
            set
            {
                orderNo = value;
                isOrder = checkOrder();
            }
        }

        public List<BasePrintSleeve> Allocation
        {
            get { return allocation; }
        }

        public List<PrintSleeve> PrintSleeve { get; set; }
        public List<PreOrder> PreOrder
        {
            get
            {
                return preOrder;
            }
        }

        public DateTime OrderTime { get; }

        public bool IsOrder
        {
            get { return isOrder; }
        }

        public Order()
        {
            allocation = new List<BasePrintSleeve>();
            PrintSleeve = new List<PrintSleeve>();
            preOrder = new List<PreOrder>();
        }

        public bool CreateOrder()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }

            string sql = $"INSERT INTO [Order]([OrderNo]) VALUES({this.OrderNo})";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = command;
            int row = dataAdapter.InsertCommand.ExecuteNonQuery();

            dataAdapter.Dispose();
            command.Dispose();
            close();

            if (row == 1) return true;
            else if (row > 1)
            {
                errorString = "Create Order more 1 Order, Please contact Administrator!";
                return false;
            }
            else
            {
                errorString = "Can't create oreder";
                return false;
            }
        }

        public bool RemoveOrder()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }

            string sql = $"DELETE FROM [Order] WHERE [OrderNo] = {this.OrderNo}";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.DeleteCommand = command;
            int result = dataAdapter.DeleteCommand.ExecuteNonQuery();

            dataAdapter.Dispose();
            command.Dispose();
            close();

            if (result > 0) return true;
            else
            {
                errorString = "Can't Delete Order";
                return false;
            }
        }

        private bool checkOrder()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }
            string sql = $"SELECT * FROM [Order] WHERE [OrderNo] = {this.OrderNo}";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            bool result = dataReader.HasRows;

            dataReader.Close();
            command.Dispose();
            close();

            return result;
        }

        public int Allocate()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return -1;
            }

            string sql;
            string sql1 = "INSERT INTO [Stage]([RollNo], [OrderNo]) VALUES";
            string sql2 = "INSERT INTO [Order_Item] VALUES";
            foreach (PrintSleeve printSleeve in this.PrintSleeve)
            {
                sql1 += $"({printSleeve.RollNo},{this.OrderNo}),";
            }
            foreach (BasePrintSleeve basePrintSleeve in Allocation)
            {

                sql2 += $"({this.OrderNo}, {basePrintSleeve.ItemNo}, {basePrintSleeve.Quantity}),";
            }
            sql = sql1.Substring(0, sql1.Length - 1) + "\n" + sql2.Substring(0, sql2.Length - 1);
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = command;
            int row = dataAdapter.InsertCommand.ExecuteNonQuery();

            dataAdapter.Dispose();
            command.Dispose();
            close();

            return row / 2;
        }
        
        public bool IsAllocate(int rollNo)
        {
            for (int i = 0; i < PrintSleeve.Count; i++)
            {
                if (PrintSleeve[i].RollNo == rollNo)
                {
                    return true;
                }
            }
            return false;
        }

        public List<PreOrder> getPreOrder(string itemNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }
            string sql = $"SELECT [PrintSleeve].[ExpireDate], [Transaction].[LocationID], [PrintSleeve].[LotNo], SUM([PrintSleeve].[Quantity]) AS Quantity, ISNULL(SUM([PreOrder].[Allocate]),0) AS Allocate FROM [PrintSleeve] INNER JOIN [Transaction] ON [PrintSleeve].[RollNo] = [Transaction].[RollNo] LEFT JOIN [PreOrder] ON [PreOrder].[LocationID] = [Transaction].[LocationID] WHERE [PrintSleeve].[ItemNo] = '{itemNo}' GROUP BY [PrintSleeve].[ExpireDate], [Transaction].[LocationID], [PrintSleeve].[LotNo] HAVING [Transaction].[LocationID] = MAX([Transaction].[LocationID]) ORDER BY [PrintSleeve].[ExpireDate], [PrintSleeve].[LotNo], [Transaction].[LocationID]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            List<PreOrder> preOrder = new List<PreOrder>();
            while (dataReader.Read())
            {
                preOrder.Add(new PreOrder(dataReader.GetDateTime(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetInt32(4)));
            }

            dataReader.Close();
            command.Dispose();
            close();

            return preOrder;
        }
        /*
        public List<OrderStage> GetOrderWithStageStatus()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }
            string sql = ""
            SqlCommand command = new

            close();
        }/**/
    }
}
