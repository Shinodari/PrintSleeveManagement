using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Item : Database
    {
        public string ItemNo { get; set; }
        public string PartNo { get; set; }

        public Item()
        {

        }

        public Item(string itemNo, string partNo)
        {
            this.ItemNo = itemNo;
            this.PartNo = partNo;
        }
        public bool setItem(string partNo)
        {
            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                return false;
            }

            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "SELECT ItemNo FROM Item WHERE PartNo = '" + partNo + "'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            int count = 0;
            string itemNo = null;
            while (dataReader.Read())
            {
                count++;
                itemNo = dataReader.GetValue(0).ToString();
            }
            if (count == 1)
            {
                this.ItemNo = itemNo;
                this.PartNo = partNo;
                dataReader.Close();
                command.Dispose();
                close();
                return true;
            }
            else
            {
                errorString = "Error: Count ItemNo find = " + count + "./nPlease contact Administrator!!!";
                dataReader.Close();
                command.Dispose();
                close();
                return false;
            }
        }
        public List<Item> getAll()
        {
            List<Item> itemList = new List<Item>();

            Database.CONNECT_RESULT connect_result = connect();
            if (connect_result == Database.CONNECT_RESULT.FAIL)
            {
                itemList = null;
                return itemList;
            }

            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "SELECT * FROM Item ORDER BY PartNo";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                itemList.Add(new Item(dataReader.GetValue(0).ToString(), dataReader.GetValue(1).ToString()));
            }
            dataReader.Close();
            command.Dispose();
            close();
            return itemList;
        }
    }
}
