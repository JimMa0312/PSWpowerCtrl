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
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();

            var str = cmdUnit.Abort();

            Assert.AreEqual("abor\n", str);
        }

        [TestMethod()]
        [DataRow(28.5, 6.0)]
        [DataRow(0, 0)]
        public void ApplyTest(double vol, double cur)
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();

            var str = cmdUnit.Apply(vol, cur);

            Assert.AreEqual($"appl {vol},{cur}\n", str);
        }

        [TestMethod()]
        [DataRow(34)]
        public void ApplyTest1(double vol)
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            var str = cmdUnit.Apply(vol);

            Assert.AreEqual($"appl {vol}\n", str);
        }

        [TestMethod()]
        [DataRow(-1.0001)]
        public void ApplyTest2(double vol)
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cmdUnit.Apply(vol));
        }

        [TestMethod()]
        [DataRow(0.0001, -1.0001)]
        public void ApplyTest3(double vol, double cur)
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cmdUnit.Apply(vol, cur));
        }

        [TestMethod()]
        [DataRow(SwitchType.OFF)]
        [DataRow(SwitchType.ON)]
        public void OutputCmdTest(SwitchType switchType)
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            Assert.AreEqual($"outp {switchType:d}\n", cmdUnit.OutputCmd(switchType));
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(0.01)]
        [DataRow(0.1)]
        [DataRow(99.99)]
        public void OutputDelayOffSecondTest(double second)
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            Assert.AreEqual($"outp:del:off {second}\n", cmdUnit.OutputDelayOffSecond(second));
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(0.01)]
        [DataRow(0.1)]
        [DataRow(99.99)]
        public void OutputDelayOnSecondTest(double second)
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            Assert.AreEqual($"outp:del:on {second}\n", cmdUnit.OutputDelayOnSecond(second));
        }

        [TestMethod()]
        [DataRow(-0.01)]
        [DataRow(100)]
        public void OutputDelayOffSecondTest1(double second)
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cmdUnit.OutputDelayOffSecond(second));
        }

        [TestMethod()]
        [DataRow(-0.01)]
        [DataRow(100)]
        public void OutputDelayOnSecondTest1(double second)
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cmdUnit.OutputDelayOnSecond(second));
        }

        [TestMethod()]
        public void QueryMeasureCurrentTest()
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();

            Assert.AreEqual("meas:curr?\n", cmdUnit.QueryMeasureCurrent());
        }

        [TestMethod()]
        public void QueryMeasurePowerTest()
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            Assert.AreEqual("meas:pow?\n", cmdUnit.QueryMeasurePower());
        }

        [TestMethod()]
        public void QueryMeasureVoltageTest()
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            Assert.AreEqual("meas:volt?\n", cmdUnit.QueryMeasureVoltage());
        }

        [TestMethod()]
        public void SystemErrorTest()
        {
            GwPWSCommdUnit cmdUnit = new GwPWSCommdUnit();
            Assert.AreEqual("syst:err?\n", cmdUnit.SystemError());
        }
    }
}