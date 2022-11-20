using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Bluetooth
    {
        static SerialPort serialPort;

        public Bluetooth()
        {
            serialPort = new SerialPort("COM4");
        }

        public void Open()
        {
            serialPort.Open();
        }

        public void Close()
        {
            serialPort.Close();
        }
    }
}
