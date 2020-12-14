using System;
using System.Text;

namespace ScpiLib
{
    public class GwPWSCommdUnit : BaseCmdUnit, IscpiCmd
    {
        public string ABORt()
        {
            strBuilder.Clear();
            strBuilder.Append("ABORt");

            return AppendExecChar(ref strBuilder);
        }

        public string APPLy(double voltage, double current = -1)
        {
            strBuilder.Clear();
            strBuilder.Append("APPLy ");

            strBuilder.Append(voltage);
            strBuilder.Append(',');
            strBuilder.Append(current);

            return AppendExecChar(ref strBuilder);
        }

        public string Initiate(TriggerType triggerType)
        {
            throw new NotImplementedException();
        }

        public string QueryMeasureCurrent()
        {
            strBuilder.Clear();
            strBuilder.Append("MEASure:CURRent");
            AppendQueryCmd(ref strBuilder);

            return AppendExecChar(ref strBuilder);
        }

        public string QueryMeasurePower()
        {
            strBuilder.Clear();
            strBuilder.Append("MEASure:VOLTage");
            AppendQueryCmd(ref strBuilder);

            return AppendExecChar(ref strBuilder);
        }

        public string QueryMeasureVoltage()
        {
            strBuilder.Clear();
            strBuilder.Append("MEASure:POWer");
            AppendQueryCmd(ref strBuilder);

            return AppendExecChar(ref strBuilder);
        }
    }
}
