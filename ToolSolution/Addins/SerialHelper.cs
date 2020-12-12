using System;
using System.Threading;
using System.IO.Ports;

namespace ToolSolution.Addins.Serial
{
    class SerialHelper
    {
        public void SerialComment(string sPort, byte[] bCmd, out byte[] bResp)
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

            bResp = null;
            serialPort.Read(bResp, 0, serialPort.BytesToRead);
            serialPort.Close();
        }
    }
}
