using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringStringBuilder
{
    static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder stringBuilder, int startIndex, int length)
        {
            StringBuilder substring = new StringBuilder(stringBuilder.ToString().Substring(startIndex, length));
            return substring;
        }

        public static StringBuilder Substring(this StringBuilder stringBuilder, int startIndex)
        {
            StringBuilder substring = new StringBuilder(stringBuilder.ToString().Substring(startIndex));
            return substring;
        }
    }
}
