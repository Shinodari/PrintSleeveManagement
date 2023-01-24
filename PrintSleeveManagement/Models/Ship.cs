using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Ship : Database
    {
        private bool selected;
        private int orderNo;
        private DateTime orderTime;
        private int itemQuantity;
        private int total;
        private int pick;
        private List<Ship> shipList;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public int OrderNo { get { return orderNo; } }

        public DateTime OrderTime { get { return orderTime; } }

        public int ItemQuantity { get { return itemQuantity; } }

        public int Total { get { return total; } }

        public int Pick { get { return pick; } }

        public List<Ship> ShipList
        {
            get { return shipList; }
        }

        public Ship()
        {
            shipList = new List<Ship>();
            GetShipList();
        }

        public Ship(int orderNo)
        {
            this.orderNo = orderNo;
        }

        public Ship(int orderNo, DateTime orderTime, int itemQuantity, int total, int pick)
        {
            this.orderNo = orderNo;
            this.orderTime = orderTime;
            this.itemQuantity = itemQuantity;
            this.total = total;
            this.pick = pick;
            this.selected = false;
        }

        public int MassShip(List<Ship> shipList)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return -1;
            }
            bool flagFrist = true;
            string sqlPick = $"SELECT [RollNo] FROM [Pick] WHERE ";
            foreach (Ship ship in shipList)
            {
                if (!flagFrist)
                    sqlPick += " OR ";
                flagFrist = false;
                sqlPick += $"[OrderNo] = '{ship.OrderNo}'";
            }
            SqlCommand command = new SqlCommand(sqlPick, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            
            string sqlShip = "INSERT INTO [Ship]([RollNo]) VALUES";
            flagFrist = true;
            while (dataReader.Read())
            {
                if (!flagFrist)
                    sqlShip += ", ";
                flagFrist = false;
                sqlShip += $"('{dataReader.GetInt32(0)}')";
            }
            dataReader.Close();
            command = new SqlCommand(sqlShip, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            int result = adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            adapter.Dispose();
            close();
            return result;
        }

        private void GetShipList()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            string sql = @"SELECT [Order].*, COUNT([PreOrder].[ItemNo]) AS ItemQuantity, SUM([PreOrder].[Quantity]) AS Total, b.[Quantity] AS Pick FROM [Order]
			                LEFT JOIN [PreOrder] ON [PreOrder].[OrderNo] = [Order].[OrderNo]
							LEFT JOIN (SELECT [Pick].[OrderNo], SUM([PrintSleeve].[Quantity]) AS Quantity FROM [Pick]
						                LEFT JOIN [PrintSleeve] ON [PrintSleeve].[RollNo] = [Pick].[RollNo]
						                GROUP BY [Pick].[OrderNo]) b
										ON [Order].[OrderNo] = b.[OrderNo]
			                LEFT JOIN (SELECT [Pick].[OrderNo], SUM([PrintSleeve].[Quantity]) AS Quantity FROM [Pick]
						                INNER JOIN [Ship] ON [Pick].[RollNo] = [Ship].[RollNo]
						                LEFT JOIN [PrintSleeve] ON [PrintSleeve].[RollNo] = [Pick].[RollNo]
						                GROUP BY [Pick].[OrderNo]) a 
										ON [Order].[OrderNo] = a.[OrderNo]
			                GROUP BY [Order].[OrderNo], [Order].[OrderTime], b.[Quantity], a.[Quantity]
			                HAVING SUM([PreOrder].[Quantity]) != ISNULL(a.[Quantity], 0)
			                ORDER BY [Order].[OrderTime]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                shipList.Add(new Ship(dataReader.GetInt32(0), dataReader.GetDateTime(1), dataReader.GetInt32(2), dataReader.GetInt32(3), dataReader.GetInt32(4)));
            }
            dataReader.Close();
            command.Dispose();
            close();
        }
    }
}
