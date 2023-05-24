using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Transaction : Database
    {
        enum TRANSACTION_STATUS
        {
            PUTAWAY,
            MOVE
        }
        int TransactionID { get; set; }
        TRANSACTION_STATUS Status { get; }
        DateTime TranactionTime { get; }

        public bool Record(string locationID, int rollNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }

            bool result = false;

            string sql = "INSERT INTO [Transaction](LocationID, RollNo)\n";
            sql += $"VALUES('{locationID}', {rollNo})";
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

        public bool Remove(int rollNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }

            /*--- This Line must develop ---*/
            //string currentLocation = GetLocationByRollNo(rollNo);

            bool result = false;
            string sql = $"DELETE FROM [Transaction] WHERE RollNo = '{rollNo}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.DeleteCommand = command;
            if (dataAdapter.DeleteCommand.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            else
            {
                errorString = "Transaction isn't find. Please contact Administrator";
                /*--- This Line must develop ---*/
                //Record(currentLocation, rollNo);
                result = false;
            }
            dataAdapter.Dispose();
            command.Dispose();
            close();
            return result;
        }

        public string GetLocationByRollNo(int rollNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return null;
            }

            string result = null;
            string sql = $"SELECT MAX([LocationID]) FROM [Transaction] WHERE [RollNo] = '{rollNo}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
                result = dataReader.GetString(0);
            dataReader.Close();
            command.Dispose();
            close();

            return result;
        }
    }
}
