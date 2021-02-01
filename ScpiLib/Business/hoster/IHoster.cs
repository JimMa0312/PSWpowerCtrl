﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib.Business.hoster
{
    public interface IHoster
    {
        void connect();
        void disconnect();

        int sendData(List<byte> buffer);
        int recvData(out List<byte> buffer);
    }
}
