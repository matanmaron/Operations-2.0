using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.Core
{
    public static class Extentions
    {
        public static string StringReverse(this string str)
        {
            if (str.Length > 0)
                return str[str.Length - 1] + StringReverse(str.Substring(0, str.Length - 1));
            else
                return str;
        }
    }
}
