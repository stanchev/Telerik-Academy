using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringInText
{
    class Program
    {
        /// <summary>
        /// Return count of substring occurrences in given text.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="substring"></param>
        /// <returns></returns>
        static int CountOfSubstringOccurrence(string text, string substring)
        {
            int substringLength = substring.Length;
            int count = 0;
            int index = text.IndexOf(substring, 0);
            
            while (index != -1)
            {
                count++;
                index += substringLength;
                index = text.IndexOf(substring, index,StringComparison.CurrentCultureIgnoreCase);                
            }

            return count;
        }

        static void Main(string[] args)
        {
            string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string substring = "in";
            Console.WriteLine(CountOfSubstringOccurrence(text, substring));
        }
    }
}
