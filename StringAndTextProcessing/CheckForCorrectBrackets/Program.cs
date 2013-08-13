using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckForCorrectBrackets
{
    class Program
    {
        /// <summary>
        /// Check for correct brackets in given expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static bool CheckBracketsInExpression(string expression)
        {
            int brackets = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    brackets++;
                }
                else if (expression[i] == ')')
                {
                    brackets--;
                    if (brackets <  0)
                    {
                        break;
                    }
                }
            }
            return brackets == 0;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter expression : ");
            string expression = Console.ReadLine();
            Console.WriteLine("Is bracket correct in expression \"{0}\" : {1}", expression,
                CheckBracketsInExpression(expression));
        }
    }
}
