using System;
using System.Text;

namespace ScpiLib.Command
{
    public class GwPWSCommdUnit : BaseCmdUnit, IscpiCmd
    {
        /// <summary>
        /// 程控终止远端任何活动
        /// </summary>
        /// <returns></returns>
        public string ABORt()
        {
            ScpiCmdBuilder.AppendCmdInMessage(ref strBuilder, EScpiCmd.Abort);
            return ScpiCmdBuilder.ToCmdMsg(strBuilder);
        }

        /// <summary>
        /// 设置电压和电流值
        /// </summary>
        /// <param name="voltage">电压值</param>
        /// <param name="current">电流值（可缺省）</param>
        /// <returns>设置电压和电流的指令快</returns>
        public string APPLy(double voltage, double current = -1)
        {
            if(voltage < 0)
            {
                throw new ApplicationException("Param [Voltage] out of range!");
            }
            ScpiCmdBuilder.AppendCmdInMessage(ref strBuilder, EScpiCmd.Apply);
            if (current > -1)
            {
                ScpiCmdBuilder.AppendParamsInMessage(ref strBuilder, voltage, current);
            }
            else if(current==-1)
            {
                ScpiCmdBuilder.AppendParamsInMessage(ref strBuilder, voltage);
            }
            else
            {
                throw new ApplicationException("Param [Current] out of range!");
            }

            return ScpiCmdBuilder.ToCmdMsg(strBuilder);
        }

        public string Initiate(TriggerType triggerType)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 创建电源输出控制指令
        /// </summary>
        /// <param name="switchType">开关量</param>
        /// <returns>电源输出控制指令</returns>
        public string OutputCmd(SwitchType switchType)
        {
            ScpiCmdBuilder.AppendCmdInMessage(ref strBuilder, EScpiCmd.Output);
            ScpiCmdBuilder.AppendParamsInMessage(ref strBuilder, (int)switchType);

            return ScpiCmdBuilder.ToCmdMsg(strBuilder);
        }
        /// <summary>
        /// 创建电源延时停止输出指令
        /// </summary>
        /// <param name="second">延时秒</param>
        /// <returns>电源延时停止输出指令</returns>
        public string OutputDelayOffSecond(double second = 0)
        {
            ScpiCmdBuilder.AppendCmdInMessage(ref strBuilder, EScpiCmd.Output, EScpiCmd.Delay, EScpiCmd.Off);
            ScpiCmdBuilder.AppendParamsInMessage(ref strBuilder, second);

            return ScpiCmdBuilder.ToCmdMsg(strBuilder);
        }
        /// <summary>
        /// 创建电源延时开始输出指令
        /// </summary>
        /// <param name="second">延时秒</param>
        /// <returns>电源延时开始输出指令</returns>
        public string OutputDelayOnSecond(double second = 0)
        {
            ScpiCmdBuilder.AppendCmdInMessage(ref strBuilder, EScpiCmd.Output, EScpiCmd.Delay, EScpiCmd.On);
            ScpiCmdBuilder.AppendParamsInMessage(ref strBuilder, second);

            return ScpiCmdBuilder.ToCmdMsg(strBuilder);
        }
        /// <summary>
        /// 创建查询采样电流值指令
        /// </summary>
        /// <returns>查询采样电流值指令</returns>
        public string QueryMeasureCurrent()
        {
            ScpiCmdBuilder.AppendCmdInMessage(ref strBuilder, EScpiCmd.Measure,EScpiCmd.Scalar, EScpiCmd.Current, EScpiCmd.Dc);
            ScpiCmdBuilder.AppendQueryInMessage(ref strBuilder);
            return ScpiCmdBuilder.ToCmdMsg(strBuilder);
        }
        /// <summary>
        /// 创建查询采样输出状态指令
        /// </summary>
        /// <returns>查询采样输出状态指令</returns>
        public string QueryMeasurePower()
        {
            ScpiCmdBuilder.AppendCmdInMessage(ref strBuilder, EScpiCmd.Measure, EScpiCmd.Scalar, EScpiCmd.Power, EScpiCmd.Dc);
            ScpiCmdBuilder.AppendQueryInMessage(ref strBuilder);
            return ScpiCmdBuilder.ToCmdMsg(strBuilder);
        }
        /// <summary>
        /// 创建查询采样电压值指令
        /// </summary>
        /// <returns>查询采样电压值指令</returns>
        public string QueryMeasureVoltage()
        {
            ScpiCmdBuilder.AppendCmdInMessage(ref strBuilder, EScpiCmd.Measure, EScpiCmd.Scalar, EScpiCmd.Voltage, EScpiCmd.Dc);
            ScpiCmdBuilder.AppendQueryInMessage(ref strBuilder);
            return ScpiCmdBuilder.ToCmdMsg(strBuilder);
        }
        /// <summary>
        /// 创建查询直流电源错误指令
        /// </summary>
        /// <returns>查询直流电源错误指令</returns>
        public string SystemError()
        {
            ScpiCmdBuilder.AppendCmdInMessage(ref strBuilder, EScpiCmd.System, EScpiCmd.Error);
            ScpiCmdBuilder.AppendQueryInMessage(ref strBuilder);
            return ScpiCmdBuilder.ToCmdMsg(strBuilder);
        }
    }
}
