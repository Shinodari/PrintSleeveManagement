using PrintSleeveManagement.View;
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
        private List<StageView> stageViewList;

        public int OrderNo { get; set; }

        public List<StageView> StageViewList
        {
            get { return stageViewList; }
        }

        public List<PrintSleeve> PrintSleeveList { get; set; }

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

        public Stage(int orderNo)
        {
            this.OrderNo = orderNo;
            stageViewList = new List<StageView>();
            PrintSleeveList = new List<PrintSleeve>();
            preStage(orderNo);
            GetStage();
        }
        private void preStage(int orderNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            string sql = $"SELECT * FROM [PreOrder] LEFT JOIN [Item] ON [PreOrder].[ItemNo] = [Item].[ItemNo] WHERE [OrderNo] = {orderNo} ORDER BY [LocationID], [PartNo], [LotNo]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                stageViewList.Add(new StageView(dataReader.GetString(7), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt32(4), dataReader.GetInt32(5), 200));
            }

            dataReader.Close();
            command.Dispose();
            close();
        }

        private void GetStage()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }
            string sql = $"SELECT * FROM [Stage] LEFT JOIN [PrintSleeve] ON [Stage].[RollNo] = [PrintSleeve].[RollNo] LEFT JOIN [Item] ON [PrintSleeve].[ItemNo] = [Item].[ItemNo] WHERE [OrderNo] = '{this.OrderNo}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PrintSleeveList.Add(new PrintSleeve(dataReader.GetInt32(0), dataReader.GetString(5), dataReader.GetString(13), dataReader.GetString(6), dataReader.GetInt32(7), dataReader.GetDateTime(8)));
            }
            dataReader.Close();
            command.Dispose();
            close();
        }
    }
}
