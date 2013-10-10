using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringStringBuilder
{
    class SubstringStringBuilderTest
    {
        static void Main(string[] args)
        {
            StringBuilder test = new StringBuilder("Test string builder substring");
            StringBuilder substring = test.Substring(5,6);
            Console.WriteLine(substring);
        }
    }
}
