using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class Order
    {
        public int OrderNo { get; }
        public DateTime OrderTime { get; }

        public Order(int orderNo, DateTime orderTime)
        {
            this.OrderNo = orderNo;
            this.OrderTime = orderTime;
        }
    }
}
