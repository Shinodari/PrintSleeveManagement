﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintSleeveManagement.Models
{    
    class Device
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

        static SerialPort serialPort = new SerialPort();

        public bool CheckInput()
        {
            switch (InputMode)
            {
                case DEVICE_INPUT_MODE.SERIAL_PORT:
                    serialPort.PortName = SerialPortIncoming;
                    try
                    {
                        serialPort.Open();
                    }
                    catch (Exception e)
                    {
                        
                    }
                    break;
            }
        }
    }
}
