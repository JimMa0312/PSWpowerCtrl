using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace ScpiLib.Business
{
    [Serializable]
    public class TargetInfo
    {
        /// <summary>
        /// 远端设备名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 使用的通信方式
        /// </summary>
        public CommunicationType CommunType { get; set; }
        /// <summary>
        /// 通信参数
        /// 
        /// 如果CommuType是 NetWork 则占用2个参数
        /// 如果CommuType是 NetWork 则占用2个参数
        /// </summary>
        public ICommunicationParam CommParam { get; set; }

        public enum CommunicationType
        {
            NetWork,
            Tty
        };

        public void setNetWorkConnectParam(string _targetIpV4Address, int _port)
        {
            CommunType = CommunicationType.NetWork;

            CommParam = new NetWorkCommunicationParam
            {
                IpAddress = _targetIpV4Address,
                Port = _port
            };
        }

        public void setTtyConnectParam(string _portName, int _baudRate, int _dataSize, float _stopSize, int _checkSum)
        {
            CommunType = CommunicationType.Tty;

            CommParam = new TtysComunicationParam
            {
                PortName = _portName,
                Baudrate = _baudRate,
                StopBits = (StopBits)(_stopSize == 1.5 ? 3 : _stopSize),
                DataBits = _dataSize,
                CheckSum = (Parity)_checkSum
            };
        }
    }
}
