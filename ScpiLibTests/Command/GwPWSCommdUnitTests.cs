using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScpiLib.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib.Command.Tests
{
    [TestClass()]
    public class GwPWSCommdUnitTests
    {
        [TestMethod()]
        public void ABORtTest()
        {
            GwPWSCommdUnit gw = new GwPWSCommdUnit();

            string target = "ABORt\r\n";

            Assert.AreEqual(target, gw.ABORt());
        }

        [TestMethod()]
        [DataRow(28.5, 12.5)]
        public void APPLyTest(double voltage, double current)
        {
            GwPWSCommdUnit gw = new GwPWSCommdUnit();


            string target = $"APPLy {voltage},{current}\r\n";

            Assert.AreEqual(target, gw.APPLy(voltage, current));
        }
    }
}