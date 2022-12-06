using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.View
{
    class OrderStage
    {
        public int OrderNo;

        public int Quantity;

        public int Allocate;

        public string Status;

        public OrderStage(int orderNo, int quantity, int allocate, string status)
        {
            this.OrderNo = orderNo;
            this.Quantity = quantity;
            this.Allocate = allocate;
            this.Status = status;
        }
    }
}
