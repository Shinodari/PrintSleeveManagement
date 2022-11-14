using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Location
    {
        enum LOCATION_STATUS
        {
            NORMAL,
            HOLD,
            ABNORMALLITY
        }

        public void putAway()
        {

        }

        string LocationID { get; set; }
        LOCATION_STATUS Status { get; set; }
        List<PrintSleeve> printSleeve { get; set; }
    }
}
