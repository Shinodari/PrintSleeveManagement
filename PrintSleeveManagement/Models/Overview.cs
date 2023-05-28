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
        public List<OverviewExpiredView> GetExpired()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            //Line 3 : (DATEADD(MONTH, 1, GETDATE())) must change to GETDATE() before Deploy
            string sql = @"SELECT [PrintSleeve].[ItemNo], [Item].[PartNo], SUM([PrintSleeve].[Quantity]) AS 'Quantity', [ExpireDate].[ExpireDate], [ExpireDate].[Time] +1 AS 'TimeExpire' FROM [PrintSleeve]
JOIN [Item] ON [Item].[ItemNo] = [PrintSleeve].[ItemNo]
JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo] AND [ExpireDate].[ExpireDate] < (DATEADD(MONTH, 1, GETDATE()))
LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
WHERE [Ship].[RollNo] IS NULL
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
JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo] AND [ExpireDate].[ExpireDate] < (DATEADD(MONTH, 1, GETDATE()))
LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
WHERE [Ship].[RollNo] IS NULL
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
JOIN [ExpireDate] ON [ExpireDate].[RollNo] = [PrintSleeve].[RollNo] AND [ExpireDate].[ExpireDate] < DATEADD(DAY, -1,DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()) +2, '1'))
LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
WHERE [Ship].[RollNo] IS NULL
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
