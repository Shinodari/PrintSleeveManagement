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
ORDER BY [ExpireDate].[ExpireDate]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            List<OverviewInProcessView> overviewInProcessView = new List<OverviewInProcessView>();
            while (dataReader.Read())
            {
                overviewInProcessView.Add(new OverviewInProcessView(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetDateTime(3), dataReader.GetInt32(4), dataReader.GetString(5), dataReader.GetDateTime(6), dataReader.GetString(7), dataReader.GetDateTime(8)));
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
WHERE [Ship].[RollNo] IS NULL AND [ExpireDate].[IRSNo] IS NULL
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
    }
}
