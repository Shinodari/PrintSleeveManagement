using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class OverviewExpiredView
    {
        public string ItemNo { get; }

        public string PartNo { get; }

        public int Quantity { get; }

        public DateTime ExpiredDate { get; }

        public int ExpiredTime { get; }

        public OverviewExpiredView(string itemNo, string partNo, int quantity, DateTime expiredDate, int expiredTime)
        {
            this.ItemNo = itemNo;
            this.PartNo = partNo;
            this.Quantity = quantity;
            this.ExpiredDate = expiredDate;
            this.ExpiredTime = expiredTime;
        }
    }
}
