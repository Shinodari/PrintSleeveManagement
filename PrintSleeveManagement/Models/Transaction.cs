using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Transaction
    {
        enum TRANSACTION_STATUS
        {
            PUTAWAY,
            MOVE
        }
        int TransactionID { get; set; }
        TRANSACTION_STATUS Status { get; }
        DateTime TranactionTime { get; }
    }
}
