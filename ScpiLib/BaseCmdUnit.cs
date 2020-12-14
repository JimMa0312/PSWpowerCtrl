using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib
{
    /// <summary>
    /// 用来描述基本指令
    /// </summary>
    public class BaseCmdUnit : IAppendExecChar, IBuildQueryCmd
    {
        protected StringBuilder strBuilder;

        public BaseCmdUnit()
        {
            strBuilder = new StringBuilder();
        }

        public string AppendExecChar(ref StringBuilder stringBuilder)
        {
            stringBuilder.Append("\r\n");

            return stringBuilder.ToString();
        }

        public void AppendQueryCmd(ref StringBuilder stringBuilder)
        {
            stringBuilder.Append("?");
        }

        public string BuildQueryCmd(string setCmd)
        {
            StringBuilder strBud = new StringBuilder(setCmd);
            strBud.Insert(strBud.Length - 2, '?');
            return strBud.ToString();
        }
    }
}
