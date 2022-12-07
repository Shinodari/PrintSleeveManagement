using PrintSleeveManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class OrderAllocate : Database
    {
        public DateTime ExpiredDate { get; }

        public string LocationId { get; }

        public string LotNo { get; }

        public int Quantity { get; }

        public int Allocate { get; set; }

        public OrderAllocate(string lotNo, int quantity, DateTime expiredDate, string locationID, int allocate)
        {
            this.LotNo = lotNo;
            this.Quantity = quantity;
            this.ExpiredDate = expiredDate;
            this.LocationId = locationID;
            this.Allocate = allocate;
        }
    }
}
