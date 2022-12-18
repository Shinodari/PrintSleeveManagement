using PrintSleeveManagement.View;
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

        public int OrderNo { get; set; }

        public List<PickView> PickViewList
        {
            get { return pickViewList; }
        }

        public List<StageView> StageList { get; set; }

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
            StageList = new List<StageView>();
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
            string sql = @"SELECT [PrintSleeve].[ItemNo], [Item].[PartNo], [PrintSleeve].[LotNo], [PrintSleeve].[RollNo], [Transaction].[LocationID], [PrintSleeve].[ExpireDate], [PrintSleeve].[Quantity], [PrintSleeve].[PONo], [PrintSleeve].[CreateTime], [PrintSleeve].[RollNoSecondary] FROM [PrintSleeve]
                LEFT JOIN [Transaction] ON [Transaction].[RollNo] = [PrintSleeve].[RollNo]
                LEFT JOIN [Item] ON [Item].[ItemNo] = [PrintSleeve].[ItemNo]";
            sql += $"WHERE [PrintSleeve].[RollNo] = '{rollNo}' ";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                StageList.Add(new StageView(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetString(4), dataReader.GetDateTime(5), dataReader.GetInt32(6), dataReader.GetInt32(7), dataReader.GetDateTime(8), dataReader.GetInt32(9)));
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

                }
            }

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
            string sql = $"SELECT [Pick].[ItemNo], [Item].[PartNo], [PrintSleeve].[LotNo], [PrintSleeve].[RollNo], [Pick].[LocationID], [PrintSleeve].[ExpireDate], [PrintSleeve].[Quantity], [PrintSleeve].[PONo], [PrintSleeve].[CreateTime], [PrintSleeve].[RollNoSecondary] FROM [Pick] LEFT JOIN [PrintSleeve] ON [Pick].[RollNo] = [PrintSleeve].[RollNo] LEFT JOIN [Item] ON [PrintSleeve].[ItemNo] = [Item].[ItemNo] WHERE [OrderNo] = '{this.OrderNo}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                StageList.Add(new StageView(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetInt32(3), dataReader.GetString(4), dataReader.GetDateTime(5), dataReader.GetInt32(6), dataReader.GetInt32(7), dataReader.GetDateTime(8), dataReader.GetInt32(9)));
            }
            dataReader.Close();
            command.Dispose();
            close();
        }
    }
}
