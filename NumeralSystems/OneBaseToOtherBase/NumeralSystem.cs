using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBaseToOtherBase
{
    class NumeralSystem
    {
        /// <summary>
        /// Convert baseX to decimal.
        /// </summary>
        /// <param name="basis"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        static int ConvertBaseToDecimal(int basis, string number)
        {
            int decimalNumber = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int digit = 0;
                switch (number[i].ToString())
                {
                    case "A": digit = 10; break;
                    case "B": digit = 11; break;
                    case "C": digit = 12; break;
                    case "D": digit = 13; break;
                    case "E": digit = 14; break;
                    case "F": digit = 15; break;
                    default: digit = int.Parse(number[i].ToString()); break;
                }
                decimalNumber += digit * (int)Math.Pow(basis, number.Length - 1 - i);
            }
            return decimalNumber;
        }
        /// <summary>
        /// Convert decimal to baseX.
        /// </summary>
        /// <param name="basis"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        static string ConvertDecimalToBase(int basis, int number)
        {
            StringBuilder binaryNumber = new StringBuilder();
            while (true)
            {
                string digit = null;
                switch (number % basis)
                {
                    case 0: digit = "0"; break;
                    case 1: digit = "1"; break;
                    case 2: digit = "2"; break;
                    case 3: digit = "3"; break;
                    case 4: digit = "4"; break;
                    case 5: digit = "5"; break;
                    case 6: digit = "6"; break;
                    case 7: digit = "7"; break;
                    case 8: digit = "8"; break;
                    case 9: digit = "9"; break;
                    case 10: digit = "A"; break;
                    case 11: digit = "B"; break;
                    case 12: digit = "C"; break;
                    case 13: digit = "D"; break;
                    case 14: digit = "E"; break;
                    case 15: digit = "F"; break;
                }
                binaryNumber.Insert(0, digit);
                number = number / basis;
                if (number == 0)
                {
                    break;
                }
            }
            return binaryNumber.ToString();
        }
        /// <summary>
        /// Convert baseX to baseX.
        /// </summary>
        /// <param name="fromBase"></param>
        /// <param name="toBase"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        static string ConverBaseToOtherBase(int fromBase, int toBase, string number)
        {
            if (fromBase < 2 || toBase > 16)
            {
                return "Invalid base";
            }
            else
            {
                return ConvertDecimalToBase(toBase, ConvertBaseToDecimal(fromBase, number));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Convert baseX to baseX.First base must be >=2, second base must be <= 16");
            Console.Write("Enter s : ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Enter d : ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("Enter number in base of s  : ");
            string number = Console.ReadLine();
            Console.WriteLine(ConverBaseToOtherBase(s, d, number));
        }
    }
}
