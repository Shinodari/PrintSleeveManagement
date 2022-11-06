using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Database
    {
        protected SqlConnection cnn;
        private string connectionString;
        private string errorString;
        
        public enum CONNECT_RESULT
        {
            SUCCESS = 901,
            FAIL = 902
        }

        public Database()
        {
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\PSMDatabase.mdf;Integrated Security=True";
        }

        public CONNECT_RESULT connect()
        {
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                return CONNECT_RESULT.SUCCESS;
            } catch (Exception e)
            {
                errorString = e.ToString();
                return CONNECT_RESULT.FAIL;
            }
        }

        public void close()
        {
            cnn.Close(); 
        }

        public string getErrorString()
        {
            return errorString;
        }
    }
}