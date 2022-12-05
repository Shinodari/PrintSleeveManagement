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
        public bool Allocate { get; set; }

        public DateTime ExpiredDate { get; }

        public string LocationId { get; }

        public string LotNo { get; }

        public int RollNo { get;}

        public int Quantity { get; }

        public OrderAllocate(int rollNo, string lotNo, int quantity, DateTime expiredDate, string locationID)
        {
            this.Allocate = false;
            this.RollNo = rollNo;
            this.LotNo = lotNo;
            this.Quantity = quantity;
            this.ExpiredDate = expiredDate;
            this.LocationId = locationID;
        }
    }
}
