using PrintSleeveManagement.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Overview : Database
    {
        public List<OverviewInProcessView> GetInProcess()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            string sql = @"SELECT [PrintSleeve].[ItemNo], [Item].[PartNo], SUM([PrintSleeve].[Quantity]) AS 'Quantity', [ExpireDate].[ExpireDate], [ExpireDate].[Time] +1 AS 'TimeExpire', 
[ExpireDate].[PriorExpiredSheetNo], [ExpireDate].[PriorExpiredSheetIssueDate], [ExpireDate].[IRSNo], [ExpireDate].[IRSIssueDate] 
FROM [PrintSleeve]
JOIN [Item] ON [Item].[ItemNo] = [PrintSleeve].[ItemNo]
JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo]
LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
WHERE [Ship].[RollNo] IS NULL AND ([ExpireDate].[PriorExpiredSheetNo] IS NOT NULL OR [ExpireDate].[IRSNo] IS NOT NULL)
GROUP BY [PrintSleeve].[ItemNo], [Item].[PartNo], [ExpireDate].[ExpireDate], [ExpireDate].[Time], [ExpireDate].[PriorExpiredSheetNo], [ExpireDate].[PriorExpiredSheetIssueDate], [ExpireDate].[IRSNo], [ExpireDate].[IRSIssueDate] 
ORDER BY [ExpireDate].[PriorExpiredSheetNo], [ExpireDate].[IRSNo]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<OverviewInProcessView> overviewInProcessView = new List<OverviewInProcessView>();
            while (dataReader.Read())
            {
                string priorExpiredNo, iRSNo;
                string priorExpiredDate, iRSDate;
                DateTime date1, date2;
                if (dataReader.IsDBNull(5))
                    priorExpiredNo = "";
                else
                    priorExpiredNo = dataReader.GetString(5);
                if (dataReader.IsDBNull(6))
                    priorExpiredDate = "";
                else
                {
                    date1 = dataReader.GetDateTime(6);
                    priorExpiredDate = date1.Date.ToString("d");
                }
                if (dataReader.IsDBNull(7))
                    iRSNo = "";
                else
                    iRSNo = dataReader.GetString(7);
                if (dataReader.IsDBNull(8))
                    iRSDate = "";
                else
                {
                    date2 = dataReader.GetDateTime(8);
                    iRSDate = date2.Date.ToString("d");
                }

                overviewInProcessView.Add(new OverviewInProcessView(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetDateTime(3), dataReader.GetInt32(4), priorExpiredNo, priorExpiredDate, iRSNo, iRSDate));
            }
            dataReader.Close();
            command.Dispose();
            close();

            return overviewInProcessView;
        }

        public List<OverviewExpiredView> GetExpired()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }
            
            string sql = @"SELECT [PrintSleeve].[ItemNo], [Item].[PartNo], SUM([PrintSleeve].[Quantity]) AS 'Quantity', [ExpireDate].[ExpireDate], [ExpireDate].[Time] +1 AS 'TimeExpire' FROM [PrintSleeve]
JOIN [Item] ON [Item].[ItemNo] = [PrintSleeve].[ItemNo]
JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo] AND [ExpireDate].[ExpireDate] < GETDATE()
LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
WHERE [Ship].[RollNo] IS NULL AND [ExpireDate].[IRSNo] IS NULL AND [ExpireDate].[PriorExpiredSheetNo] IS NULL
GROUP BY [PrintSleeve].[ItemNo], [Item].[PartNo], [ExpireDate].[ExpireDate], [ExpireDate].[Time]
ORDER BY [ExpireDate].[ExpireDate]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<OverviewExpiredView> overviewExpireViewList = new List<OverviewExpiredView>();
            while (dataReader.Read())
            {
                overviewExpireViewList.Add(new OverviewExpiredView(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetDateTime(3), dataReader.GetInt32(4)));
            }
            dataReader.Close();
            command.Dispose();
            close();

            return overviewExpireViewList;
        }

        public List<OverviewExpiredView> GetPriorExpired()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            string sql = @"SELECT [PrintSleeve].[ItemNo], [Item].[PartNo], SUM([PrintSleeve].[Quantity]) AS 'Quantity', [ExpireDate].[ExpireDate], [ExpireDate].[Time] +1 AS 'TimeExpire' FROM [PrintSleeve]
JOIN [Item] ON [Item].[ItemNo] = [PrintSleeve].[ItemNo]
JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo] AND [ExpireDate].[ExpireDate] > GETDATE() AND [ExpireDate].[ExpireDate] < (DATEADD(MONTH, 1, GETDATE()))
LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
WHERE [Ship].[RollNo] IS NULL AND [ExpireDate].[PriorExpiredSheetNo] IS NULL AND [ExpireDate].[IRSNo] IS NULL
GROUP BY [PrintSleeve].[ItemNo], [Item].[PartNo], [ExpireDate].[ExpireDate], [ExpireDate].[Time]
ORDER BY [ExpireDate].[ExpireDate]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<OverviewExpiredView> overviewExpireViewList = new List<OverviewExpiredView>();
            while (dataReader.Read())
            {
                overviewExpireViewList.Add(new OverviewExpiredView(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetDateTime(3), dataReader.GetInt32(4)));
            }
            dataReader.Close();
            command.Dispose();
            close();

            return overviewExpireViewList;
        }

        public List<OverviewExpiredView> GetPriorExpiredNextMonth()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            string sql = @"SELECT [PrintSleeve].[ItemNo], [Item].[PartNo], SUM([PrintSleeve].[Quantity]) AS 'Quantity', [ExpireDate].[ExpireDate], [ExpireDate].[Time] +1 AS 'TimeExpire' FROM [PrintSleeve]
JOIN [Item] ON [Item].[ItemNo] = [PrintSleeve].[ItemNo]
JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo] AND [ExpireDate].[ExpireDate] > DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()) +1, '1') AND [ExpireDate].[ExpireDate] < DATEADD(DAY, -1,DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()) +2, '1'))
LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
WHERE [Ship].[RollNo] IS NULL AND [ExpireDate].[PriorExpiredSheetNo] IS NULL AND [ExpireDate].[IRSNo] IS NULL
GROUP BY [PrintSleeve].[ItemNo], [Item].[PartNo], [ExpireDate].[ExpireDate], [ExpireDate].[Time]
ORDER BY [ExpireDate].[ExpireDate]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<OverviewExpiredView> overviewExpireViewList = new List<OverviewExpiredView>();
            while (dataReader.Read())
            {
                overviewExpireViewList.Add(new OverviewExpiredView(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetDateTime(3), dataReader.GetInt32(4)));
            }
            dataReader.Close();
            command.Dispose();
            close();

            return overviewExpireViewList;
        }
        public List<IssueSheetView> GetLotList(string itemNo, string expiredDate)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            string sql = $@"SELECT [PrintSleeve].[LotNo], [PrintSleeve].[RollNo], [ExpireDate].[ExpireDate], [ExpireDate].[Time], 
[ExpireDate].[PriorExpiredSheetNo], [ExpireDate].[PriorExpiredSheetIssueDate] 
FROM [PrintSleeve] 
JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo]
WHERE [PrintSleeve].[ItemNo] = '{itemNo}' AND [ExpireDate].[ExpireDate] = '{expiredDate}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            List<IssueSheetView> result = new List<IssueSheetView>();
            while (dataReader.Read())
            {
                string issueNo;
                string issueDate;
                if (!dataReader.IsDBNull(4))
                    issueNo = dataReader.GetString(4);
                else
                    issueNo = null;
                if (!dataReader.IsDBNull(5))
                    issueDate = dataReader.GetDateTime(5).ToString();
                else
                    issueDate = null;
                result.Add(new IssueSheetView(dataReader.GetString(0), dataReader.GetInt32(1), dataReader.GetDateTime(2), dataReader.GetInt32(3) +1, issueNo, issueDate));
            }
            dataReader.Close();
            command.Dispose();
            close();

            return result;
        }
    }
}
