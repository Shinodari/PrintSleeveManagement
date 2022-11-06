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
        public int ItemNo { get; set; }
        public string PartNo { get; set; }

        public Item()
        {

        }

        public Item(int itemNo, string partNo)
        {
            this.ItemNo = itemNo;
            this.PartNo = partNo;
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
            string sql = "SELECT * FROM Item";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                itemList.Add(new Item(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString()));
            }
            close();
            return itemList;
        }
    }
}
