using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class PrintSleeve : BasePrintSleeve
    {
        public void create(Receipt receipt, string itemNo, string rollNo, DateTime expiredDate)
        {

        }

        public void create(Receipt receipt, string itemNo, string rollNo, DateTime expiredDate, int quantity)
        {

        }

        string RollNo { get; set; }
        Receipt Receipt { get; set; }
        string LotNo { get; set; }
        string RollNoSecondary { get; set; }
        DateTime ExpiredDate { get; set; }
        
        
    }
}
