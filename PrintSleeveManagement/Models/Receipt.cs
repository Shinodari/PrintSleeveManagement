﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Receipt : Database
    {
        public Receipt(int poNo)
        {
            this.PONo = poNo;
            PrintSleeve = new List<BasePrintSleeve>();
        }
        
        public int receiveAll()
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                return -1;
            }
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            bool flagFirstValue = true;
            string sql = "INSERT INTO Receipt(PONo, ItemNo, Quantity, Receiver) VALUES";
            foreach (BasePrintSleeve printSleeve in PrintSleeve)
            {
                if (flagFirstValue)
                {
                    flagFirstValue = false;
                } else
                {
                    sql += ",";
                }
                sql += "(" + this.PONo + ",'" + printSleeve.ItemNo + "'," + printSleeve.Quantity + ",'" + Authentication.Username + "')";
            }

            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = command;
            int row = adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            close();
            return row;
        }

        public int PONo { get; set; }
        public List<BasePrintSleeve> PrintSleeve { get; }
        public DateTime ReceiptTime { get; set; }
        public string Receiver { get; set; }
    }
}
