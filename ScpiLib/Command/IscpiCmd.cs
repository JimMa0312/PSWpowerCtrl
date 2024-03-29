﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib.Command
{
    public enum TriggerType
    {
        Transient,
        Output
    }

    public enum SwitchType
    {
        OFF,
        ON
    }

    /// <summary>
    /// 用来描述SCPI标准指令接口
    /// </summary>
    public interface IscpiCmd
    {
        /// <summary>
        /// ABORt 指令 清除所有的触发方式
        /// </summary>
        /// <returns>返回组成ABORt指令的字符串</returns>
        string Abort();
        /// <summary>
        /// 用于设置电源的输出最大电压和输出最大电流
        /// </summary>
        /// <param name="voltage">设备允许额定电压的0%~105%值</param>
        /// <param name="current">设备允许额定电流的0%~105%值，该值默认为复数</param>
        /// <returns>组织成Apply的值</returns>
        string Apply(double voltage, double current=-1);

        /// <summary>
        /// 用于设置出发方式
        /// </summary>
        /// <param name="triggerType">使用的出发方式</param>
        /// <returns></returns>
        string Initiate(TriggerType triggerType);

        /// <summary>
        /// 查询输出的
        /// </summary>
        /// <returns></returns>
        string QueryMeasureCurrent();
        string QueryMeasureVoltage();
        string QueryMeasurePower();
        string OutputDelayOnSecond(double second=0);
        string OutputDelayOffSecond(double second = 0);
        string OutputCmd(SwitchType switchType);
        string SystemError();
    }
}
