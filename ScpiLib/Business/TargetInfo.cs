using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib.Business
{
    [Serializable]
    public class TargetInfo
    {
        public string name { get; set; }
        public CommunicationType communType { get; set; }
        public string[] commParam { get; set; }

        public enum CommunicationType
        {
            NetWork,
            Tty
        };

        public void setNetWorkConnectParam(string _targetIpV4Address, int _port)
        {
            if(commParam==null)
            {
                commParam = new string[2];
            }

            commParam[0] = _targetIpV4Address;
            commParam[1] = _port.ToString();
        }

        public void setTtyConnectParam(string _portName, int _baudRate, int _dataSize, float _stopSize, int _checkSum)
        {
            if(commParam == null)
            {
                commParam = new string[5];
            }

            commParam[0] = _portName;
            commParam[1] = _baudRate.ToString();
            commParam[2] = _dataSize.ToString();
            commParam[3] = _stopSize.ToString();
            commParam[4] = _checkSum.ToString();
        }
    }
}
