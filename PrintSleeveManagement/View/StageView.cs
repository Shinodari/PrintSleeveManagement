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

        public int PONo { get; set; }

        public DateTime CreateTime { get; set; }

        //Future is remove this property
        public int RollNoSec { get; set; }

        public StageView(string itemNo, string partNo, string lotNo, int rollNo, string locationID, DateTime exprieDate, int quantity, int pONo, DateTime createTime, int rollNoSec)
        {
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.RollNo = rollNo;
            this.LocationID = locationID;
            this.ExprieDate = exprieDate;
            this.Quantity = quantity;
            this.PONo = pONo;
            this.CreateTime = createTime;
            this.RollNoSec = rollNoSec;
        }
    }
}
