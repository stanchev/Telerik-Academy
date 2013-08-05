using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToHexadecimal
{
    public class BinaryToHexadecimal
    {
        /// <summary>
        /// Return hexadecimal digit.
        /// </summary>
        /// <param name="digit"></param>
        /// <returns></returns>
        static string GetHexDigit(string digit)
        {
            string hexDigit = null;
            switch (digit)
            {
                case "0000": hexDigit = "0"; break;
                case "0001": hexDigit = "1"; break;
                case "0010": hexDigit = "2"; break;
                case "0011": hexDigit = "3"; break;
                case "0100": hexDigit = "4"; break;
                case "0101": hexDigit = "5"; break;
                case "0110": hexDigit = "6"; break;
                case "0111": hexDigit = "7"; break;
                case "1000": hexDigit = "8"; break;
                case "1001": hexDigit = "9"; break;
                case "1010": hexDigit = "A"; break;
                case "1011": hexDigit = "B"; break;
                case "1100": hexDigit = "C"; break;
                case "1101": hexDigit = "D"; break;
                case "1110": hexDigit = "E"; break;
                case "1111": hexDigit = "F"; break;
            }
            return hexDigit;
        }
        /// <summary>
        /// Convert binary to hexadecimal.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ConvertBinaryToHexadecimal(string number)
        {
            StringBuilder hexDigit = new StringBuilder();
            string binaryNumber = number;
            int addBits = binaryNumber.Length % 4;
            if (addBits != 0)
            {
                for (int i = 0; i < (4 - addBits); i++)
                {
                    binaryNumber = binaryNumber.Insert(0, "0");
                }
            }
            for (int i = 0; i < binaryNumber.Length; i+=4)
            {
                string halfByte = binaryNumber.Substring(i, 4);
                hexDigit.Append(GetHexDigit(halfByte));
            }
            return hexDigit.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertBinaryToHexadecimal("1111"));
        }
    }
}
