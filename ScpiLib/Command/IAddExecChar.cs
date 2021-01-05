using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib.Command
{
    public interface IAppendExecChar
    {
        string AppendExecChar(ref StringBuilder stringBuilder);
    }

    public interface IBuildQueryCmd
    {
        string BuildQueryCmd(string setCmd);
        void AppendQueryCmd(ref StringBuilder stringBuilder);
    }
}
