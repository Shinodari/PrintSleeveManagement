using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class PreOrder
    {
        public DateTime ExpiredDate { get; }

        public string LocationId { get; }

        public string LotNo { get; }

        public int Quantity { get; }

        public int Allocate { get; set; }

        public PreOrder(DateTime expiredDate, string locationID, string lotNo, int quantity, int allocate)
        {
            this.LotNo = lotNo;
            this.Quantity = quantity;
            this.ExpiredDate = expiredDate;
            this.LocationId = locationID;
            this.Allocate = allocate;
        }
    }
}
