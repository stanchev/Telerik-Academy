using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfPolynomials
{
    public class Polynomials
    {
        public static int[] SumOfPolynomials(int[] firstPolynomial, int[] secondPolynomial)
        {
            int maxLength = firstPolynomial.Length > secondPolynomial.Length ?
                firstPolynomial.Length : secondPolynomial.Length;
            int minLength = firstPolynomial.Length < secondPolynomial.Length ?
                firstPolynomial.Length : secondPolynomial.Length;
            int lenghtDifference = firstPolynomial.Length - secondPolynomial.Length;
            int[] result = new int[maxLength];
            for (int i = 0; i < minLength; i++)
            {
                result[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            if (lenghtDifference == 0)
            {
                return result;
            }
            else if (lenghtDifference < 0)
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    result[i] = secondPolynomial[i];
                }
                return result;
            }
            else
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    result[i] = firstPolynomial[i];
                }
                return result;
            }
        }

        public static void PrintPolinomial(int[] Polinomial)
        {
            StringBuilder result = new StringBuilder();
            Array.Reverse(Polinomial);
            bool first = true;
            for (int i = 0; i < Polinomial.Length - 1; i++)
            {
                if (Polinomial[i] != 0 && Polinomial[i] > 0)
                {
                    if (first)
                    {
                        result.AppendFormat("{0}x^{1}", Polinomial[i], Polinomial.Length - 1 - i);
                        first = false;
                    }
                    else
                    {
                        result.AppendFormat(" + {0}x^{1}", Polinomial[i], Polinomial.Length - 1 - i);
                    }
                }
                if (Polinomial[i] != 0 && Polinomial[i] < 0)
                {
                    result.AppendFormat(" {0}x^{1}", Polinomial[i], Polinomial.Length - 1 - i);
                }
            }
            if (Polinomial[Polinomial.Length-1] != 0)
            {
                if (Polinomial[Polinomial.Length - 1] > 0)
                {
                    result.AppendFormat(" + {0}", Polinomial[Polinomial.Length - 1]);
                }
                else
                {
                    result.AppendFormat(" {0}", Polinomial[Polinomial.Length - 1]);
                }
            }
            Console.WriteLine(result.ToString());
        }

        static void Main(string[] args)
        {
            int[] firstPolynomial = { -1,-5,2 }; // x^0 x^1 x^2
            int[] secondPolynomial = { 0,0,-3};
            int[] result = SumOfPolynomials(firstPolynomial, secondPolynomial);
            PrintPolinomial(result);
        }
    }
}
