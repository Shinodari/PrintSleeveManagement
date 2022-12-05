using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Order : Database
    {
        public int OrderNo { get; set; }

        public List<BasePrintSleeve> Allocation
        {
            get
            {
                return new List<BasePrintSleeve>();
            }
            set { }
        }

        public List<PrintSleeve> PrintSleeve { get; set; }

        public DateTime OrderTime { get; }

        public Order()
        {
            PrintSleeve = new List<PrintSleeve>();
        }
        
        public bool IsAllocate(int rollNo)
        {
            for (int i = 0; i < PrintSleeve.Count; i++)
            {
                if (PrintSleeve[i].RollNo == rollNo)
                {
                    return true;
                }
            }
            return false;
        }/**/
    }
}
