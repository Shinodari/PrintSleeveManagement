using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class AdjustView
    {
        DateTime newExpiredDate;
        bool scrap;

        public bool Selecte { get; set; }
        public string PartNo { get; }
        public int RollNo { get; }
        public string LotNo { get; }
        public int Time { get; }
        public DateTime OldExpiredDate { get; }
        public DateTime NewExpiredDate { get { return newExpiredDate; } }
        public bool Scrap {
            get { return scrap; }
            set
            {
                scrap = value;
                if (scrap == true)
                    this.newExpiredDate = DateTime.MinValue;
            }
        }

        public AdjustView(string partNo, string lotNo, int rollNo, int time, DateTime expiredDate)
        {
            this.PartNo = partNo;
            this.LotNo = lotNo;
            this.RollNo = rollNo;
            this.OldExpiredDate = expiredDate;
            this.Time = time;
        }

        public void SetExtendDate(DateTime newExpiredDate)
        {
            this.newExpiredDate = newExpiredDate;
            this.scrap = false;
        }

        public void SetScrap()
        {
            this.scrap = true;
            this.newExpiredDate = DateTime.MinValue;
        }
    }
}
