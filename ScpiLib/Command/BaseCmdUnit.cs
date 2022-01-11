using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib.Command
{
    /// <summary>
    /// 用来描述基本指令
    /// </summary>
    public class BaseCmdUnit
    {
        protected StringBuilder strBuilder;

        public BaseCmdUnit()
        {
            strBuilder = new StringBuilder();
        }
    }
}
