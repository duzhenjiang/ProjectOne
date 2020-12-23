using System;
using System.Threading;
using System.IO.Ports;

namespace SerialHelper
{
    public class Serial
    {
        public byte[] SerialCommend(string sPort, byte[] bCmd)
        {
            SerialPort serialPort = new SerialPort
            {
                WriteTimeout = 5000,
                ReadTimeout = 5000,
                PortName = sPort,
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None
            };

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

            byte[] bResp = new byte[serialPort.BytesToRead];
            serialPort.Read(bResp, 0, bResp.Length);
            serialPort.Close();
            return bResp;
        }
    }
}