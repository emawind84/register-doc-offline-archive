using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmis
{
    public static class StringExtension
    {
        internal static String[] Lines(this String text)
        {
            return text.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
