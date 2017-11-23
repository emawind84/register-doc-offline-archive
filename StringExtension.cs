using System;

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
