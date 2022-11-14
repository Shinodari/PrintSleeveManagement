using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class PrintSleeve : BasePrintSleeve
    {
        public PrintSleeve(int pONo)
        {

        }
        public void create(Receipt receipt, string itemNo, string rollNo, DateTime expiredDate)
        {

        }

        public void create(Receipt receipt, string itemNo, string rollNo, DateTime expiredDate, int quantity)
        {

        }

        int RollNo { get; set; }
        int PONo { get; }
        string LotNo { get; set; }
        int RollNoSecondary { get; set; }
        DateTime ExpiredDate { get; set; }
        
        
    }
}
