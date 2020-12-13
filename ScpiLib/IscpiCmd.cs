using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib
{
    public enum TriggerType
    {
        Transient,
        Output
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
        string ABORt();
        /// <summary>
        /// 用于设置电源的输出最大电压和输出最大电流
        /// </summary>
        /// <param name="voltage">设备允许额定电压的0%~105%值</param>
        /// <param name="current">设备允许额定电流的0%~105%值，该值默认为复数</param>
        /// <returns>组织成Apply的值</returns>
        string APPLy(double voltage, double current=-1);

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
        string MeasureCurrent();

        /// <summary>
        /// 根据控制指令，生成查询指令
        /// </summary>
        /// <param name="setCmd"></param>
        /// <returns></returns>
        string Query(string setCmd);
    }
}
