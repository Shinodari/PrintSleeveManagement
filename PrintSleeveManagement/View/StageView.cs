using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class StageView
    {
        public string ItemNo { get; set; }

        public string PartNo { get; set; }

        public string LotNo { get; set; }

        public int RollNo { get; set; }

        public string LocationID { get; set; }

        public DateTime ExprieDate { get; set; }

        public int Quantity { get; set; }

        public int ReceiptNo { get; set; }

        public DateTime CreateTime { get; set; }

        public StageView(string itemNo, string partNo, string lotNo, int rollNo, string locationID, DateTime exprieDate, int quantity, int receiptNo, DateTime createTime)
        {
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.RollNo = rollNo;
            this.LocationID = locationID;
            this.ExprieDate = exprieDate;
            this.Quantity = quantity;
            this.ReceiptNo = receiptNo;
            this.CreateTime = createTime;
        }
    }
}
