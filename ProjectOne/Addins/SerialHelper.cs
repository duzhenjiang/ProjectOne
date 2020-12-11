using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace Addins.Serial
{
    class SerialHelper
    {
        public void SerialComment(string sPort, byte[] bCmd, out byte[] bResp)
        {
            SerialPort serialPort = new SerialPort();
            serialPort.WriteTimeout = 5000;
            serialPort.ReadTimeout = 5000;
            serialPort.PortName = sPort;
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;

            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
            else 
            {
                serialPort.Close();
                serialPort.Open();
            }

            serialPort.Write(bCmd, 0, bCmd.Length);
            while (serialPort.BytesToRead == 0)
            {
                Thread.Sleep(10);
            }
            Thread.Sleep(50);

            bResp = null;
            serialPort.Read(bResp, 0, serialPort.BytesToRead);
            serialPort.Close();
        }
    }
}
