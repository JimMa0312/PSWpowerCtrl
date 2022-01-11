using System;
using System.Collections.Generic;
using System.Text;

namespace ScpiLib.Exceptions
{
    public class StringEmptyException:ApplicationException
    {
        public StringEmptyException(string message):base(message)
        {

        }
    }
}
