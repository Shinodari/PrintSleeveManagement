using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Order : Database
    {
        PrintSleeve printSleeve;
        public int OrderNo { get; set; }

        public Order()
        {
            printSleeve = new PrintSleeve();
        }

        public List<BasePrintSleeve> Allocation
        {
            get
            {
                return new List<BasePrintSleeve>();
            }
        }

        public DateTime OrderTime { get; }
    }
}
