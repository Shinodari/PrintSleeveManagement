using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class PutAwayLocaionView
    {
        public int RollNo { get; }
        public int PONo { get; }
        public string ItemNo { get; }
        public string PartNo { get; }
        public string LotNo { get; }
        public int Quantity { get; }
        public DateTime ExpiredDate { get; }

        public PutAwayLocaionView(int rollNo, int pONo, string itemNo, string partNo, string lotNo, int quantity, DateTime expiredDate)
        {
            this.RollNo = rollNo;
            this.PONo = pONo;
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.Quantity = quantity;
            this.ExpiredDate = expiredDate;
        }
    }
}
