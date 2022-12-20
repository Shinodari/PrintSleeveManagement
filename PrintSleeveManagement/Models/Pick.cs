﻿using PrintSleeveManagement.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Pick : Database
    {
        private List<PickView> pickViewList;
        private List<StageView> stageList;

        public int OrderNo { get; set; }

        public List<PickView> PickViewList
        {
            get { return pickViewList; }
        }

        public List<StageView> StageList
        {
            get { return stageList; }
        }

        public string RequestStage
        {
            get
            {
                Database.CONNECT_RESULT connect_result = connect();
                if (connect_result == Database.CONNECT_RESULT.FAIL)
                {
                    errorString = "Can't connect database. Please contact Administrator";
                    return null;
                }
                string sql = $"SELECT * FROM [PreOrder] LEFT JOIN [Item] ON [PreOrder].[ItemNo] = [Item].[ItemNo] WHERE [OrderNo] = '{this.OrderNo}'";
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                string result = "";
                string location = "";
                string itemNo = "";
                while (dataReader.Read())
                {
                    if (location != dataReader.GetString(2))
                    {
                        location = dataReader.GetString(2);
                        itemNo = "";
                        result += $"Location: {location}\n".PadRight(30)+$"{dataReader.GetString(7)}\n".PadRight(50)+$"Lot No: {dataReader.GetString(3)} Q'ty {dataReader.GetInt32(5)}\n";
                    }
                    else
                    {
                        if (itemNo != dataReader.GetString(1))
                        {
                            itemNo = dataReader.GetString(1);
                            result += $"\t{dataReader.GetString(7)}\n\t\tLot No: {dataReader.GetString(3)} Q'ty {dataReader.GetInt32(5)}\n";
                        }
                        else
                        {
                            result += $"\t\tLot No: {dataReader.GetString(3)} Q'ty {dataReader.GetInt32(5)}\n";
                        }
                    }                    
                }
                dataReader.Close();
                command.Dispose();
                close();

                return result; ;
            }
        }

        public Pick(int orderNo)
        {
            this.OrderNo = orderNo;
            pickViewList = new List<PickView>();
            stageList = new List<StageView>();
            GetPick();
            PrePick(orderNo);
            UpdateStage();
        }

        public bool AddPrintSleeve(int rollNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }
            string sql = @"SELECT [PrintSleeve].[ItemNo], [Item].[PartNo], [PrintSleeve].[LotNo], [PrintSleeve].[RollNo], [Transaction].[LocationID], [PrintSleeve].[ExpireDate], [PrintSleeve].[Quantity], [PrintSleeve].[PONo], [PrintSleeve].[CreateTime], ISNULL([PrintSleeve].[RollNoSecondary], 0) AS RollNoSecondary FROM [PrintSleeve]
                LEFT JOIN [Transaction] ON [Transaction].[RollNo] = [PrintSleeve].[RollNo]
                LEFT JOIN [Item] ON [Item].[ItemNo] = [PrintSleeve].[ItemNo]";
            sql += $"WHERE [PrintSleeve].[RollNo] = '{rollNo}' ";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                stageList.Add(new StageView(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetString(4), dataReader.GetDateTime(5), dataReader.GetInt32(6), dataReader.GetInt32(7), dataReader.GetDateTime(8), dataReader.GetInt32(9)));
            }
            dataReader.Close();
            command.Dispose();
            close();

            return true;
        }

        public bool AddPrintSleeve(int rollNo, int rollNoSec)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }
            string sql = "SELECT [PrintSleeve].[RollNo], [Transaction].[LocationID] FROM [PrintSleeve] JOIN [Transaction] ON [Transaction].[RollNo] = [PrintSleeve].[RollNo]\n";
            sql += $"WHERE ([PrintSleeve].[RollNo] = '{rollNo}' AND [RollNoSecondary] = '{rollNoSec}')\n";
            sql += $"OR ([PrintSleeve].[RollNo] = '{rollNoSec}' AND [RollNoSecondary] = '{rollNo}')";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            int count = 0;
            List<int> rollNoList = new List<int>();
            List<string> locationIDList = new List<string>();
            while (dataReader.Read())
            {
                count++;
                rollNoList.Add(dataReader.GetInt32(0));
                locationIDList.Add(dataReader.GetString(1));
            }
            dataReader.Close();
            command.Dispose();
            close();

            if (rollNoList.Count > 1)
            {
                if (locationIDList[0] == locationIDList[1])
                {
                    AddPrintSleeve(rollNoList[0]);
                }
                else
                {
                    errorString = "DifferantLocation";
                    return false;
                }
            }
            else
                AddPrintSleeve(rollNoList[0]);

            return true;
        }

        public bool AddPrintSleeve(int rollNo, int rollNoSec, string locationID)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }
            string sql = "SELECT [PrintSleeve].[RollNo], [Transaction].[LocationID] FROM [PrintSleeve] JOIN [Transaction] ON [Transaction].[RollNo] = [PrintSleeve].[RollNo]\n";
            sql += $"WHERE ([PrintSleeve].[RollNo] = '{rollNo}' AND [RollNoSecondary] = '{rollNoSec}')\n";
            sql += $"OR ([PrintSleeve].[RollNo] = '{rollNoSec}' AND [RollNoSecondary] = '{rollNo}')\n";
            sql += $"AND [LocationID] = '{locationID}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            List<int> rollNoList = new List<int>();
            while (dataReader.Read())
            {
                rollNoList.Add(dataReader.GetInt32(0));
            }
            AddPrintSleeve(rollNoList[0]);
            dataReader.Close();
            command.Dispose();
            close();
            return true;
        }

        public void UpdateStage()
        {
            for (int i = 0; i < pickViewList.Count; i++)
            {
                PickView pickView = pickViewList[i];
                int stage = 0;
                foreach (StageView stageView in StageList)
                {
                    if (pickView.PartNo == stageView.PartNo && pickView.LocationID == stageView.LocationID && pickView.LotNo == stageView.LotNo)
                        stage += stageView.Quantity;
                }
                pickViewList[i].Stage = stage;
            }
        }

        public int Stage()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return -1;
            }
            string sqlClear = $"DELETE FROM [Pick] WHERE [OrderNo] = {this.OrderNo}";
            string sql = "INSERT INTO [Pick]([OrderNo], [ItemNo], [LocationID], [RollNo]) VALUES";
            foreach (StageView sv in stageList)
            {
                sql += $"('{this.OrderNo}','{sv.ItemNo}','{sv.LocationID}','{sv.RollNo}'),";
            }
            sql = sql.Substring(0, sql.Length - 1);

            SqlCommand command = new SqlCommand(sqlClear, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();

            command.CommandText = sql;
            adapter.InsertCommand = command;
            int row = adapter.InsertCommand.ExecuteNonQuery();

            adapter.Dispose();
            command.Dispose();
            close();

            return row;
        }

        private void PrePick(int orderNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            string sql = @"SELECT [Item].[PartNo], [Allocate].[LocationID], [Allocate].[LotNo], [Allocate].[Allocate] FROM [Allocate] 
                LEFT JOIN [Item] ON [Allocate].[ItemNo] = [Item].[ItemNo] 
                LEFT JOIN [PreOrder] ON [Allocate].[OrderNo] = [PreOrder].[OrderNo] AND [Allocate].[ItemNo]	= [PreOrder].[ItemNo]
                LEFT JOIN [Pick] ON [Allocate].[OrderNo] = [Pick].[OrderNo] AND [Allocate].[ItemNo] = [Pick].[ItemNo] AND [Allocate].[LocationID] = [Pick].[LocationID] ";
            sql += $"WHERE [Allocate].[OrderNo] = {this.OrderNo}\n";
            sql += "ORDER BY [Allocate].[LocationID], [Item].[PartNo], [Allocate].[LotNo]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                pickViewList.Add(new PickView(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3)));
            }

            dataReader.Close();
            command.Dispose();
            close();
        }

        private void GetPick()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            string sql = $"SELECT [Pick].[ItemNo], [Item].[PartNo], [PrintSleeve].[LotNo], [PrintSleeve].[RollNo], [Pick].[LocationID], [PrintSleeve].[ExpireDate], [PrintSleeve].[Quantity], [PrintSleeve].[PONo], [PrintSleeve].[CreateTime], ISNULL([PrintSleeve].[RollNoSecondary],0) FROM [Pick] LEFT JOIN [PrintSleeve] ON [Pick].[RollNo] = [PrintSleeve].[RollNo] LEFT JOIN [Item] ON [PrintSleeve].[ItemNo] = [Item].[ItemNo] WHERE [OrderNo] = '{this.OrderNo}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                stageList.Add(new StageView(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetString(4), dataReader.GetDateTime(5), dataReader.GetInt32(6), dataReader.GetInt32(7), dataReader.GetDateTime(8), dataReader.GetInt32(9)));
            }
            dataReader.Close();
            command.Dispose();
            close();
        }
    }
}
