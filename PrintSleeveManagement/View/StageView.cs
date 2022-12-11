using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class StageView
    {
        public string LocationID { get; set; }

        public string PartNo { get; set; }

        public string LotNo { get; set; }

        public int Quantity { get; set; }

        public int Allocate { get; set; }

        public int Stage { get; set; }

        public StageView(string partNo, string locationID, string lotNo, int quantity, int allocate, int stage)
        {
            this.PartNo = partNo;
            this.LocationID = locationID;
            this.LotNo = lotNo;
            this.Quantity = quantity;
            this.Allocate = allocate;
            this.Stage = stage;
        }
    }
}
