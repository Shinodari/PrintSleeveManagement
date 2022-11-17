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
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }

            bool result = false;

            string sql = "INSERT INTO [Transaction](LocationID, RollNo)\n";
            sql += $"VALUES('{this.LocationID}', {printSleeve.RollNo})";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = command;
            if (dataAdapter.InsertCommand.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            dataAdapter.Dispose();
            command.Dispose();
            close();
            return result;
        }

        public string LocationID { get; set; }
        public string Status { get; set; }
        public List<PrintSleeve> printSleeve { get; set; }
    }
}
