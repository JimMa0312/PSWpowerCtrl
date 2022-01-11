using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace BootLoadConfigApp
{
    class Program
    {
        static readonly string pateryStr = "Press any key to stop auto-boot...\r";
        static void Main(string[] args)
        {
            SerialPort serialPort = new SerialPort("COM3");

            serialPort.BaudRate = 115200;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;

            serialPort.Handshake = Handshake.None;
            serialPort.RtsEnable = true;
            serialPort.Open();

            StringBuilder strBuilder = new StringBuilder();
            bool isOnTx = true;
            while (true)
            {
                //int recv_len = serialPort.BytesToRead;
                //for (int i = 0; i < recv_len; i++)
                //{
                //    strBuilder.Append((char)serialPort.ReadChar());
                //}

                //Console.Write(strBuilder);
                //strBuilder.Clear();

                string recvStr=serialPort.ReadLine();

                Console.WriteLine(recvStr);

                if(recvStr.Equals(pateryStr))
                {
                    serialPort.WriteLine("\r\n");
                }
            }
        }
    }
}
