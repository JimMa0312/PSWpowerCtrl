using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace ScpiLib.Business
{
    public interface ICommunicationParam
    {

    }

    public sealed class NetWorkCommunicationParam: ICommunicationParam
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
    }

    public sealed class TtysComunicationParam: ICommunicationParam
    {
        public string PortName { get; set; }
        public int Baudrate { get; set; }
        public StopBits StopBits { get; set; }
        public int DataBits { get; set; }
        public Parity CheckSum { get; set; }
    }
}
