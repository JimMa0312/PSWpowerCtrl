using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScpiLib.Business.hoster;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib.Business.hoster.Tests
{
    [TestClass()]
    public class TcpClientHosterTests
    {
        TcpClientHoster tcpClientHoster;

        [TestInitialize]
        public void configTest()
        {
            tcpClientHoster = new TcpClientHoster("192.168.0.101", 2268);
            tcpClientHoster.connect();

        }
        [TestMethod()]
        public void connectTest()
        {
            tcpClientHoster.connect();
        }

        [TestMethod()]
        public void sendDataTest()
        {
            string command = "OUTPut:STATe:IMMediate 1\r\n";
            List<byte> buffer = new List<byte>(Encoding.ASCII.GetBytes(command));
            tcpClientHoster.sendData(buffer);
        }

        [TestCleanup]
        public void cleanTest()
        {
            tcpClientHoster.disconnect();
        }
    }
}