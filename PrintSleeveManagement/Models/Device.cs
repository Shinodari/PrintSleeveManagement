using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{    
    class Device : SerialPort
    {
        public enum DEVICE_INPUT_MODE
        {
            SERIAL_PORT = 1,
            HID_KEYBORD = 2
        }

        public static DEVICE_INPUT_MODE InputMode
        {
            get { return (DEVICE_INPUT_MODE) Properties.Settings.Default.InputMode; }
            set { Properties.Settings.Default.InputMode = (short) value; }
        }

        public static string SerialPortIncoming
        {
            get { return Properties.Settings.Default.SerialPortIncoming; }
            set { Properties.Settings.Default.SerialPortIncoming = value; }
        }

        public static string SerialPortOutgoing
        {
            get { return Properties.Settings.Default.SerialPortOutgoing; }
            set { Properties.Settings.Default.SerialPortOutgoing = value; }
        }

        public string ErrorString;

        SerialPort serialPort;

        public bool CheckInput()
        {
            switch (InputMode)
            {
                case DEVICE_INPUT_MODE.SERIAL_PORT:
                    PortName = SerialPortIncoming;
                    try
                    {
                        Open();
                        for (int i = 0; i < 2; ++i)
                        {
                            int timeOut = 5;
                            while (!DsrHolding && timeOut > 0)
                            {
                                Thread.Sleep(1000);
                                --timeOut;
                            }
                            Thread.Sleep(3000);
                        }
                        if (!DsrHolding)
                        {
                            ErrorString = "DSR Time Out!";
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        ErrorString = e.Message;
                        return false;
                    }
                    break;
            }
            return true;
        }

        public bool Activate(string outgoingPort, string incomingPort)
        {
            SerialPort outComPort = new SerialPort(outgoingPort);
            SerialPort inComPort = new SerialPort(incomingPort);

            if (inComPort.IsOpen || outComPort.IsOpen)
            {
                outComPort.Close();
                inComPort.Close();
            }

            try
            {
                outComPort.Open();
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message + "\n";
            }
            try
            {
                inComPort.Open();
                
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message + "\n";
            }

            int checkTime = 5;
            int timeOut = 5;
            for (int i = 0; i < checkTime; ++i)
            {
                while (!inComPort.DsrHolding)
                {
                    Thread.Sleep(timeOut * 1000);
                }
                Thread.Sleep(1000);
            }

            if (!inComPort.DsrHolding)
            {
                outComPort.Close();
                inComPort.Close();
                ErrorString = "Activated is Error!\nPlease setting and try agian.";
                return false;
            }

            SerialPortIncoming = incomingPort;
            serialPort = inComPort;
            return true;
        }
    }
}
