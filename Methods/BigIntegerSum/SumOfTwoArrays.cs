using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigIntegerSum
{
    class SumOfTwoArrays
    {
        static byte[] CalculateSumOfArrays(byte[] firstArray, byte[] secondArray)
        {
            List<byte> result = new List<byte>();
            byte sumOfElements = 0;

            for (int i = 0; i < firstArray.Length; i++)
            {
                sumOfElements += (byte)(firstArray[i] + secondArray[i]);
                if (sumOfElements > 9)
                {
                    result.Add((byte)(sumOfElements - 10));
                    sumOfElements = 1;
                }
                else
                {
                    result.Add(sumOfElements);
                    sumOfElements = 0;
                }
            }
            if (sumOfElements != 0)
            {
                result.Add(sumOfElements);
            }
            Array.Reverse(result.ToArray());
            return result.ToArray();
        }

        static void FillArray(string number, byte[] array)
        {
            for (int i = number.Length - 1; i >= 0; i--)
            {
                array[number.Length - 1 - i] = Byte.Parse(number[i].ToString());
            }
        }

        static void PrintArray(byte[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string firstNumber = "1";
            string secondNumber = "10";
            
            int size = firstNumber.Length >= secondNumber.Length ? firstNumber.Length : secondNumber.Length;
            byte[] firstArray = new byte[size];
            FillArray(firstNumber, firstArray);

            byte[] secondArray = new byte[size];
            FillArray(secondNumber, secondArray);

            Console.Write("Sum of integer is : ");
            PrintArray(CalculateSumOfArrays(firstArray,secondArray));
        }
    }
}
