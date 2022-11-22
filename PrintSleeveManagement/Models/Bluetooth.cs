using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{
    class Bluetooth
    {
        public string PortName { get; set; }
        public bool IsOpen => serialPort.IsOpen;

        Thread thread;  
        static SerialPort serialPort;

        public Bluetooth()
        {
            Start();
        }

        public Bluetooth(string portName)
        {
            this.PortName = portName;
            Start();
        }

        private void Start()
        {
            thread = new Thread(Read);
            serialPort = new SerialPort(PortName);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();

        }

        private void Read()
        {
            
        }
        
        public void Open()
        {
            serialPort.Open();
        }

        public void Close() => serialPort.Close();
        
    }
}
