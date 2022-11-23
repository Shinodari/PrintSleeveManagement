using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{    
    class Device
    {

        public static string SerialPortName;

        public Device()
        {
            SerialPortName = Properties.Settings.Default.SerialPort;
        }

        public void Activate(List<string> listPortName)
        {
            
        }
    }
}
