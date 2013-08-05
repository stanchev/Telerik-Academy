using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SumOfPolynomials;

namespace ExtendPolynomials
{
    class ExtendedPolinomials
    {
        static int[] SubstarctionOfPolynomials(int[] firstPolynomial, int[] secondPolynomial)
        {
            int maxLength = firstPolynomial.Length > secondPolynomial.Length ?
                firstPolynomial.Length : secondPolynomial.Length;
            int minLength = firstPolynomial.Length < secondPolynomial.Length ?
                firstPolynomial.Length : secondPolynomial.Length;
            int lenghtDifference = firstPolynomial.Length - secondPolynomial.Length;
            int[] result = new int[maxLength];
            for (int i = 0; i < minLength; i++)
            {
                result[i] = firstPolynomial[i] - secondPolynomial[i];
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
        static int[] MultiplicationOfPolynomials(int[] firstPolynomial, int[] secondPolynomial)
        {
            int maxLength = firstPolynomial.Length > secondPolynomial.Length ?
                firstPolynomial.Length : secondPolynomial.Length;
            int minLength = firstPolynomial.Length < secondPolynomial.Length ?
                firstPolynomial.Length : secondPolynomial.Length;
            int lenghtDifference = firstPolynomial.Length - secondPolynomial.Length;
            int[] result = new int[maxLength];
            for (int i = 0; i < minLength; i++)
            {
                result[i] = firstPolynomial[i] * secondPolynomial[i];
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

        static void Main(string[] args)
        {
            int[] firstPolynomial = { 2, 2, 1 }; // x^0 x^1 x^2
            int[] secondPolynomial = { 1, 4,3 };
            int[] sumResult = Polynomials.SumOfPolynomials(firstPolynomial, secondPolynomial);
            Polynomials.PrintPolinomial(sumResult);
            int[] substarctionResult = SubstarctionOfPolynomials(firstPolynomial, secondPolynomial);
            Polynomials.PrintPolinomial(substarctionResult);
            int[] multiplicationResult = MultiplicationOfPolynomials(firstPolynomial, secondPolynomial);
            Polynomials.PrintPolinomial(multiplicationResult);
        }
    }
}
