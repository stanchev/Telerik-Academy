using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexadecimalToDecimal
{
    class HexadecimalToDecimal
    {
        /// <summary>
        /// Convert hexadecimal to decimal.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static int ConvertHexadecimalToDecimal(string number)
        {
            int decimalNumber = 0, digit = 0;
            for (int i = 0; i < number.Length; i++)
            {
                switch (number[i])
                {
                    case 'A':
                    case 'a': digit = 10; break;
                    case 'B':
                    case 'b': digit = 11; break;
                    case 'C':
                    case 'c': digit = 12; break;
                    case 'D':
                    case 'd': digit = 13; break;
                    case 'E':
                    case 'e': digit = 14; break;
                    case 'F':
                    case 'f': digit = 15; break;
                    default: digit = int.Parse(number[i].ToString()); break;
                }

                decimalNumber += digit*(int)Math.Pow(16, number.Length - 1 - i);

            }
            return decimalNumber;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertHexadecimalToDecimal("EF10"));
        }
    }
}
