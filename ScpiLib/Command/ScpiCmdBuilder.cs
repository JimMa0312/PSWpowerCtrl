using ScpiLib.attribute;
using ScpiLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib.Command
{
    public class ScpiCmdBuilder
    {
        public static void AppendCmdInMessage(ref StringBuilder stringBuilder, params EScpiCmd[] cmdset)
        {
            int index = 0;

            if(stringBuilder==null)
            {
                stringBuilder = new StringBuilder();
            }
            else
            {
                stringBuilder.Clear();
            }

            //首先处理第一条指令
            if(stringBuilder.Length==0 && cmdset.Length>0)
            {
                stringBuilder.Append(cmdset[index].GetDisplayName());
                index++;
            }

            //处理剩下的指令
            for (index = 1; index < cmdset.Length; index++)
            {
                if(cmdset[index].IsSquareBracketItem()==false)
                {
                    stringBuilder.Append(':').Append(cmdset[index]);
                }
            }
        }

        public static void AppendParamsInMessage(ref StringBuilder stringBuilder, params object[] paramset)
        {
            if(stringBuilder?.Length==0)
            {
                throw new StringEmptyException("StringBuilder is Empty!");
            }

            stringBuilder?.Append(' ');

            for (int i = 0; i < paramset.Length; i++)
            {
                stringBuilder?.Append(paramset[i]);

                if(i!=paramset.Length-1)
                {
                    stringBuilder?.Append(',');
                }
            }
        }

        public static void AppendQueryInMessage(ref StringBuilder stringBuilder)
        {
            if (stringBuilder?.Length == 0)
            {
                throw new StringEmptyException("StringBuilder is Empty!");
            }

            stringBuilder?.Append('?');
        }

        public static string ToCmdMsg(StringBuilder stringBuilder)
        {
            stringBuilder?.Append('\n');

            return stringBuilder?.ToString();
        }
    }
}
