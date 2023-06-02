using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class AdjustView
    {
        public bool Selecte { get; set; }
        public string PartNo { get; }
        public int RollNo { get; }
        public string LotNo { get; }
        public int Time { get; }
        public DateTime ExpiredDate { get; }
        public DateTime ExtendDate { get; set; }
        public bool Scrap { get; }

        public AdjustView(string partNo, string lotNo, int rollNo, int time, DateTime expiredDate)
        {
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.RollNo = rollNo;
            this.ExpiredDate = expiredDate;
            this.Time = time;
        }

        public void SetExtendDate(DateTime extendDate)
        {
            this.ExtendDate = extendDate;
        }
    }
}
