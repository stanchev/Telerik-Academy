using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertStringToUnicodeCharacters
{
    class Program
    {
        /// <summary>
        /// Convert string to unicode representation.
        /// </summary>
        /// <param name="text"></param>
        static void ConvertStringToUnicode(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                int charNumber = text[i];
                Console.Write("\\u{0:x4}", charNumber);                
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ConvertStringToUnicode("Hi!");
        }
    }
}
