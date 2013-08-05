using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Factorial
{
    class Factorial
    {
        static BigInteger[] factorials = new BigInteger[101];
        
        static BigInteger ReturnFactorial(int number)
        {
            BigInteger factorial = factorials[number - 1] * number;
            factorials[number] = factorial;
            return factorial;
        }

        static void Main(string[] args)
        {
            factorials[0] = 1;
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Factorial of {0} is : {1}", i, ReturnFactorial(i));
            }
        }
    }
}
