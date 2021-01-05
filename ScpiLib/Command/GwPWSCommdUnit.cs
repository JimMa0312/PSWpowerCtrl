using System;
using System.Text;

namespace ScpiLib.Command
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
            if(voltage < 0)
            {
                throw new ApplicationException("Param [Voltage] out of range!");
            }
            strBuilder.Clear();
            strBuilder.Append("APPLy ");

            strBuilder.Append(voltage);
            if (current > -1)
            {
                strBuilder.Append(',');
                strBuilder.Append(current);
            }
            else if(current < -1)
            {
                throw new ApplicationException("Param [Current] out of range!");
            }

            return AppendExecChar(ref strBuilder);
        }

        public string Initiate(TriggerType triggerType)
        {
            throw new NotImplementedException();
        }

        public string OutputCmd(SwitchType switchType)
        {
            strBuilder.Clear();
            strBuilder.Append("OUTPut ");
            strBuilder.Append(switchType);

            return AppendExecChar(ref strBuilder);
        }

        public string OutputDelayOffSecond(double second = 0)
        {
            strBuilder.Clear();
            strBuilder.Append("OUTPut:DELay:OFF ");
            strBuilder.Append(second);

            return AppendExecChar(ref strBuilder);
        }

        public string OutputDelayOnSecond(double second = 0)
        {
            strBuilder.Clear();
            strBuilder.Append("OUTPut:DELay:ON ");
            strBuilder.Append(second);

            return AppendExecChar(ref strBuilder);
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

        public string SystemError()
        {
            strBuilder.Clear();
            strBuilder.Append("SysTem:ERRor");
            AppendQueryCmd(ref strBuilder);

            return AppendExecChar(ref strBuilder);
        }
    }
}
