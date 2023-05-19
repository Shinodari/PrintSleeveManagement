using PrintSleeveManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class ReceiptPrintSleeve
    {
        public string ItemNo { get; }
        public string PartNo { get; }
        public int Quantity { get; }

        public ReceiptPrintSleeve(string itemNo, int quantity)
        {
            this.ItemNo = itemNo;
            Item item = new Item(itemNo);
            this.PartNo = item.PartNo;
            this.Quantity = quantity;
        }

        public ReceiptPrintSleeve(string itemNo, string partNo, int quantity)
        {
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.Quantity = quantity;
        }
    }
}
