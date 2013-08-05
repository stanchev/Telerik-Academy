using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToDecimal
{
    class BinaryToDecimal
    {
        /// <summary>
        /// Convert binary to decimal.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static int ConvertBinaryToDecimal(string number)
        {
            int decimalNumber = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] != '0')
                {
                    decimalNumber += (int)Math.Pow(2, number.Length - 1 - i);
                }
            }
            return decimalNumber;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertBinaryToDecimal("111101"));
        }
    }
}
