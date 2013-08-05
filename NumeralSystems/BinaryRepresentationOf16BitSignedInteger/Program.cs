using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRepresentationOf16BitSignedInteger
{
    class Program
    {
        /// <summary>
        /// Get binary representation of short.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static string GetBinaryRepresentationOfShorWithBitOperations(short number)
        {
            StringBuilder binaryNumber = new StringBuilder();
            short mask = 1;
            for (short i = 0; i < 16; i++)
            {
                if ((mask & number) == 1)
                {
                    binaryNumber.Insert(0,"1");
                }
                else
                {
                    binaryNumber.Insert(0, "0");
                }
                number = (short)(number >> 1);
            }
            return binaryNumber.ToString();
        }

        /// <summary>
        /// Get binary representation of short.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static string GetBinaryRepresentationOfShort(short number)
        {
            string binaryRepresentation = Convert.ToString(number, 2);
            int binaryLength = binaryRepresentation.Length;
            if (binaryLength < 16)
            {
                for (int i = 0; i < 16 - binaryLength; i++)
                {
                    binaryRepresentation = binaryRepresentation.Insert(0, "0");
                }
            }
            return binaryRepresentation;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetBinaryRepresentationOfShort(33));
            Console.WriteLine(GetBinaryRepresentationOfShorWithBitOperations(33));
        }
    }
}
