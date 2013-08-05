using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexadecimalToBinary
{
    class HexadecimalToBinary
    {
        /// <summary>
        /// Convert hexadecimal to binary.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static string ConvertHexadecimalToBinary(string number)
        {
            StringBuilder binaryNumber = new StringBuilder();
            int digit = 0;
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
                int count = 0;
                while (true)
                {
                    binaryNumber.Insert(i*4, digit % 2);
                    count++;
                    digit = digit / 2;
                    if (digit == 0)
                    {
                        if (count < 4)
                        {
                            for (int j = 0; j < 4-count; j++)
                            {
                                binaryNumber.Insert(i*4, 0);
                            }
                        }
                        break;
                    }
                }
            }
            return binaryNumber.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertHexadecimalToBinary("EFB19"));
        }
    }
}
