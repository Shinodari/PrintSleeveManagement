using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class IssueSheetView
    {
        public bool Selecte { get; set; }
        public int RollNo { get; }
        public string LotNo { get; }
        public DateTime ExpiredDate { get; }
        public int Time { get; }
        public string PriorExpiredSheetNo { get; }
        public string PriorExpiredSheetDate { get; }

        public IssueSheetView(string lotNo, int rollNo, DateTime expiredDate, int time, string priorExpiredSheetNo, string priorExpredSheetDate)
        {
            this.LotNo = lotNo;
            this.RollNo = rollNo;
            this.ExpiredDate = expiredDate;
            this.Time = time;
            this.PriorExpiredSheetNo = priorExpiredSheetNo;
            this.PriorExpiredSheetDate = priorExpredSheetDate;
        }
    }
}
