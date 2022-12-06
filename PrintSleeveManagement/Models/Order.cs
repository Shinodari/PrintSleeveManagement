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
            get
            {
                return new List<BasePrintSleeve>();
            }
            set { }
        }

        public List<PrintSleeve> PrintSleeve { get; set; }

        public DateTime OrderTime { get; }

        public bool IsOrder
        {
            get { return isOrder; }
        }

        public Order()
        {
            PrintSleeve = new List<PrintSleeve>();
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

            string sql = "INSERT INTO [Stage]([RollNo], [OrderNo]) VALUES";
            foreach (PrintSleeve printSleeve in this.PrintSleeve)
            {
                sql += $"({printSleeve.RollNo},{this.OrderNo}),";
            }
            sql.Substring(0, sql.Length - 1);
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = command;
            int row = dataAdapter.InsertCommand.ExecuteNonQuery();
            dataAdapter.Dispose();
            command.Dispose();
            close();

            return row;
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
        }/**/
    }
}
