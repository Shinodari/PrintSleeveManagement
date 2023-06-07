using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Location : Database
    {
        enum LOCATION_STATUS
        {
            NORMAL=300,
            HOLD=301,
            ABNORMALLITY=302
        }

        public Location()
        {

        }

        public Location(string locationID)
        {
            this.LocationID = locationID;
        }

        public Location(string locationID, int status)
        {
            this.LocationID = locationID;
            LOCATION_STATUS location_status = (LOCATION_STATUS)status;
            this.Status = location_status.ToString();
        }

        public string GetLocation(int rollNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            string sql =  $@"SELECT [LocationID] FROM [Transaction] WHERE [RollNo] = '{rollNo}' 
AND [TransactionID] = (SELECT MAX([TransactionID]) FROM [Transaction] e WHERE e.[TransactionID] = [Transaction].[TransactionID])";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            string result = null;
            if (dataReader.Read())
            {
                result = dataReader.GetString(0);
            }
            dataReader.Close();
            command.Dispose();
            close();

            return result;
        }

        public List<Location> GetAllLocation()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }
            List<Location> listLocation = new List<Location>();
            String sql = "SELECT * FROM Location";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                listLocation.Add(new Location(dataReader.GetString(0), dataReader.GetInt32(1)));
            }
            dataReader.Close();
            command.Dispose();
            close();
            return listLocation;
        }

        public bool PutAway(PrintSleeve printSleeve)
        {
            Transaction transaction = new Transaction();
            if (transaction.Record(this.LocationID, printSleeve.RollNo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsLocation(string locationID)
        {
            bool result = false;
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                return false;
            }
            string sql = $"SELECT LocationID FROM Location WHERE LocationID ='{locationID}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
                result = true;

            dataReader.Close();
            command.Dispose();
            close();
            return result;
        }

        private void getPrintSleeve(string locationID)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                return;
            }
            string sql = $@"SELECT [PrintSleeve].[RollNo], [PrintSleeve].[ReceiptNo], [PrintSleeve].[ItemNo], 
                            [Item].[PartNo], [PrintSleeve].[LotNo], 
                            [PrintSleeve].[Quantity], [PrintSleeve].[ExpireDate],
                            MAX([Transaction].[TransactionTime]) AS [TransactionTime] FROM [PrintSleeve]
                            INNER JOIN [Item] ON [PrintSleeve].[ItemNo] = [Item].[ItemNo]
                            INNER JOIN [Transaction] ON [PrintSleeve].[RollNo] = [Transaction].[RollNo]
                            LEFT JOIN [Ship] ON [PrintSleeve].[RollNo] = [Ship].[RollNo]
                            WHERE [Transaction].[LocationID] = '{locationID}' AND [Ship].[RollNo] IS NULL
                            GROUP BY [PrintSleeve].[RollNo], [PrintSleeve].[RollNo], [PrintSleeve].[ReceiptNo], [PrintSleeve].[ItemNo], [PrintSleeve].[LotNo], [PrintSleeve].[Quantity], [PrintSleeve].[ExpireDate], 
                            [Item].[PartNo], [Ship].[RollNo]";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PrintSleeveList.Add(new PrintSleeve(dataReader.GetInt32(0), 
                    dataReader.GetInt32(1), 
                    dataReader.GetString(2), 
                    dataReader.GetString(3), 
                    dataReader.GetString(4), 
                    dataReader.GetInt32(5), 
                    dataReader.GetDateTime(6)));
            }
            dataReader.Close();
            command.Dispose();
            close();
        }

        /// <summary>
        /// Move Location for PrintSleeve
        /// </summary>
        /// <param name="printsleeve">PrintSleeve to be move to another location</param>
        /// <returns>Old Location</returns>
        public string Move(PrintSleeve printsleeve)
        {
            if (this.LocationID == null)
            {
                errorString = "This Location is wrag!";
                return null;
            }

            string oldLocation = GetLocation(printsleeve.RollNo);

            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            string sql = $"INSERT INTO [Transaction]([LocationID],[RollNo]) VALUES('{this.LocationID}','{printsleeve.RollNo}')";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            if (adapter.InsertCommand.ExecuteNonQuery() == 1)
            {
                return oldLocation;
            }
            else
            {
                errorString = "Can't Move This PrintSleeve. Please contact Administrator";
                return null;
            }
        }

        public string LocationID { get; set; }
        public string Status { get; set; }
        public List<PrintSleeve> PrintSleeveList { get; set; }
    }
}
