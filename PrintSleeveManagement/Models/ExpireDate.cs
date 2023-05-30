using PrintSleeveManagement.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class ExpireDate : Database
    {
        public int RollNo { get; }

        public DateTime ExpiredDate { get; }

        public DateTime ExtendDate { get; }

        public int Time { get; }

        public ExpireDate(int rollNo)
        {
            this.RollNo = rollNo;
        }

        //Don't sure, this function will use
        private void GetExpireDateByRollNo()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return;
            }

            close();
        }

        public bool SetFirstExpireDate(DateTime expireDate)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }

            string sql = $"INSERT INTO [expireDate]([RollNo],[ExpireDate]) VALUES({this.RollNo},'{expireDate}')";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.InsertCommand = command;
            if (dataAdapter.InsertCommand.ExecuteNonQuery() == 1)
                return true;
            else
                return false;
        }

        public bool RemoveExpireDate()
        {
            bool result;
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }
            string sql = $"DELETE FROM [ExpireDate] WHERE [RollNo] = '{this.RollNo}'";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.DeleteCommand = command;
            int i = adapter.DeleteCommand.ExecuteNonQuery();
            if (i > 0)
            {
                result = true;
            }
            else
            {
                errorString = "ExpireDate of this PrintSleeve can't Remove!\nPlease contact Adimistrator";
                result = false;
            }
            adapter.Dispose();
            command.Dispose();
            close();
            return result;
        }
                
        public bool IssueIRS(string issueNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                errorString = "Can't connect database. Please contact Administrator";
                return false;
            }

            string sql = $@"UPDATE [ExpireDate] e SET [IRSNo] = '{issueNo}', [IRSIssueDate] = '{DateTime.Now}' WHERE [RollNo] = {this.RollNo} 
AND [Time] = (SELECT MAX[Time] FROM [ExpireDate] WHERE e.[RollNo] = [RollNo])";
            int result;

            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = command;
            result = adapter.UpdateCommand.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            else if (result > 1)
            {
                errorString = "ERROR: SQL UPDATE MORE THANE 1 ROW, PLESS CONTRACT ADMIN!";
                return false;
            }
            else
            {
                errorString = "ERROR: SQL NOT UPDATE, PLESS CONTRACT ADMIN!";
                return false;
            }
        }
    }
}
