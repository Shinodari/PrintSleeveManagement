using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class BasePrintSleeve : Item
    {
        public BasePrintSleeve()
        {

        }

        public BasePrintSleeve(string itemNo, int quantity) : base(itemNo)
        {
            this.Quantity = quantity;
        }

        public BasePrintSleeve(string itemNo, string partNo, int quantity) : base(itemNo, partNo)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; set; }
    }
}
