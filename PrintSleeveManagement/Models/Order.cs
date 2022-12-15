﻿using PrintSleeveManagement.View;
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
        //private List<BasePrintSleeve> allocation;
        private List<PreOrder> preOrder;
        private List<Stage> stage;
        private bool isOrder;

        public int OrderNo
        {
            get { return orderNo; }
            set
            {
                orderNo = value;
                isOrder = checkOrder();
                if (isOrder) PullDatabase();
            }
        }
        /*
        public List<BasePrintSleeve> Allocation
        {
            get { return allocation; }
        }/**/

        public List<PreOrder> PreOrder
        {
            get { return preOrder; }
        }

        public List<Stage> Stage { get { return stage; } }

        public DateTime OrderTime { get; }

        public bool IsOrder
        {
            get { return isOrder; }
        }

        public Order()
        {
            //allocation = new List<BasePrintSleeve>();
            preOrder = new List<PreOrder>();
        }

        public Order(int orderNo) : this()
        {
            this.OrderNo = orderNo;
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

        private void PullDatabase()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            string sql = $"SELECT [PreOrder].[ItemNo], [Item].[PartNo], SUM([PreOrder].[Quantity]) AS Quantiry, SUM([PreOrder].[Allocate]) AS Allocate FROM [PreOrder]  ";
            sql += $"LEFT JOIN [Item] ON [PreOrder].[ItemNo] = [Item].[ItemNo] WHERE [OrderNo] = '{this.orderNo}' ";
            sql += $"GROUP BY [PreOrder].[OrderNo], [PreOrder].[ItemNo], [Item].[PartNo]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                preOrder.Add(new PreOrder(this.OrderNo, dataReader.GetString(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetInt32(3)));
            }
            dataReader.Close();
            command.Dispose();
            close();
        }

        public int Allocate()
        {
            if (!IsOrder) CreateOrder();

            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return -1;
            }
            string sql = $"DELETE FROM [PreOrder] WHERE [OrderNo] = '{this.OrderNo}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.DeleteCommand = command;
            dataAdapter.DeleteCommand.ExecuteNonQuery();

            sql = "INSERT INTO [PreOrder] VALUES ";
            foreach (PreOrder pod in preOrder)
            {
                foreach (OrderAllocate oac in pod.OrderAllocate)
                {
                    if (oac.Allocate > 0) {
                        sql += $"({this.OrderNo}, '{pod.ItemNo}', '{oac.LocationId}', '{oac.LotNo}', {pod.Quantity}, {oac.Allocate}),";
                    }
                }
            }
            sql = sql.Substring(0, sql.Length - 1);
            command.CommandText = sql;
            dataAdapter.InsertCommand = command;
            int row = dataAdapter.InsertCommand.ExecuteNonQuery();

            dataAdapter.Dispose();
            command.Dispose();
            close();

            return row;
        }        
    }
}
