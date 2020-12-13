using System;
using System.Text;

namespace ScpiLib
{
    public class SCPISCommand
    {
        /// <summary>
        /// 根据输入的电压值和电流值组织“APPLy”指令
        /// </summary>
        /// <param name="vol">电压值</param>
        /// <param name="current">电流值</param>
        /// <returns>组织好的APPLy指令字符串</returns>
        public static string APPLy(decimal vol, decimal current)
        {
            StringBuilder strBud = new StringBuilder("APPLy ");

            strBud.Append(vol);
            strBud.Append(',');
            strBud.Append(current);

            SCPISCommand.AppendSimpleCharEnter(ref strBud);

            return strBud.ToString();
        }

        public static string APPLy(string volStr, string currentStr)
        {
            if (false == volStr.Equals("MIN") && false == volStr.Equals("MAX"))
            {
                //TODO
            }

            if (false == currentStr.Equals("MIN") && false == currentStr.Equals("MAX"))
            {
                //TODO
            }

            StringBuilder strBud = new StringBuilder("APPLy ");

            strBud.Append(volStr);
            strBud.Append(',');
            strBud.Append(currentStr);

            SCPISCommand.AppendSimpleCharEnter(ref strBud);

            return strBud.ToString();
        }



        private static void AppendSimpleCharEnter(ref StringBuilder strBuild)
        {
            strBuild.Append("\r\n");
        }

        /// <summary>
        /// 将set指令转换为query指令
        /// </summary>
        /// <param name="lastSendCmdStr">需要转换为query指令的set指令</param>
        /// <returns>query指令</returns>
        public static string QueryCmd(string lastSendCmdStr)
        {
            StringBuilder strBud = new StringBuilder(lastSendCmdStr);
            strBud.Insert(strBud.Length - 2, '?');
            return strBud.ToString();
        }
    }
}
