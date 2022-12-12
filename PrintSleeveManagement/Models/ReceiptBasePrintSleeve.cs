using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class ReceiptBasePrintSleeve : BasePrintSleeve
    {
        public ReceiptBasePrintSleeve()
        {

        }

        public ReceiptBasePrintSleeve(string itemNo, string partNo, int quantity) : base(itemNo, partNo, quantity)
        {
            Moved = 0;
        }

        public ReceiptBasePrintSleeve(string itemNo, string partNo, int quantity, int available) : base(itemNo, partNo, quantity)
        {
            Moved = available;
        }

        public int Moved { get; set; }
    }
}
