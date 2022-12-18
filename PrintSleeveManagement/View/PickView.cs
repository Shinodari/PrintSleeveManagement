using PrintSleeveManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class PickView
    {
        public string LocationID { get; set; }

        public string PartNo { get; set; }

        public string LotNo { get; set; }

        public int Allocate { get; set; }

        public int Stage { get; set; }

        public PickView(string partNo, string locationID, string lotNo, int allocate)
        {
            this.PartNo = partNo;
            this.LocationID = locationID;
            this.LotNo = lotNo;
            this.Allocate = allocate;
            this.Stage = 0;
        }
    }
}
