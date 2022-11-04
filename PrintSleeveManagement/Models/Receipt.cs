using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Receipt : BasePrintSleeve
    {
        public int PONo { get; set; }
        public DateTime ReceiptTime { get; set; }
    }
}
