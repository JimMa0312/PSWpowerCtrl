using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib.Business.hoster
{
    public interface IHoster
    {
        bool connect();
        bool disconnect();

        int sendData(List<byte> buffer);
        int recvData(out List<byte> buffer);
    }
}
