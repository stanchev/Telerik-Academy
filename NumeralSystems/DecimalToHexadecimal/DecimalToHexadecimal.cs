using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryToHexadecimal;
using DecimalToBinary;

namespace DecimalToHexadecimal
{
    class DecimalToHexadecimal
    {
        /// <summary>
        /// Convert decimal to hexadecimal.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static string ConvertDecimalToHexadecimal(int number)
        {
            return BinaryToHexadecimal.BinaryToHexadecimal.ConvertBinaryToHexadecimal(
                DecimalToBinary.DecimalToBinary.ConvertDecimalToBinary(number));
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertDecimalToHexadecimal(Int32.MinValue));
        }
    }
}
