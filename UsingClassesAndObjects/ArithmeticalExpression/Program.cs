using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ArithmeticalExpression
{
    class Program
    {
        static bool badArithmeticExpression = false;

        /// <summary>
        /// Calculates functions in given arithmetical expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static string CalculateExpressionInFunctions(string expression)
        {
            string pattern = @"(sqrt\([\-]*[\d\.]+\))|(ln\([\-]*[\d\.]+\))|(pow\([\-]*[\d\.]+\,[\-]*[\d\.]+\))";
            Regex regExpression = new Regex(pattern, RegexOptions.Compiled);

            while (regExpression.IsMatch(expression))
            {
                expression = regExpression.Replace(expression, new MatchEvaluator(
                    delegate(Match match)
                    {
                        if (match.Value[0] == 's')
                        {
                            Match number = Regex.Match(match.Value, @"[\-]*[\d\.]+");
                            double result = Math.Sqrt(Double.Parse(number.Value.Replace('.', ',')));
                            if (double.IsNaN(result))
                            {
                                badArithmeticExpression = true;
                            }
                            return result.ToString().Replace(',', '.');
                        }
                        else if (match.Value[0] == 'l')
                        {
                            Match number = Regex.Match(match.Value, @"[\-]*[\d\.]+");
                            double result = Math.Log(Double.Parse(number.Value.Replace('.', ',')));
                            if (double.IsNaN(result))
                            {
                                badArithmeticExpression = true;
                            }
                            return result.ToString().Replace(',', '.');
                        }
                        else
                        {
                            string powFunction = match.Value.Remove(0, 4);
                            powFunction = powFunction.Remove(powFunction.Length - 1, 1);
                            string[] numbers = powFunction.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            double result = Math.Pow(double.Parse(
                                numbers[0].Replace('.', ',')), double.Parse(numbers[1].Replace('.', ',')));
                            return result.ToString().Replace(',', '.');
                        }
                    }
                    ));
            }
            return expression;
        }

        /// <summary>
        /// Calculates expression in brackets in given arithmetical expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static string CalculateExpressionInBrackets(string expression)
        {
            string pattern = @"\([\d\.\+\-\*\/]+\)";
            Regex regExpression = new Regex(pattern, RegexOptions.Compiled);

            while (regExpression.IsMatch(expression))
            {
                expression = regExpression.Replace(expression, new MatchEvaluator(
                    delegate(Match match)
                    {
                        string bracketsExpression = match.Value.Trim(new char[] { '(', ')' });
                        return CalculateExpression(bracketsExpression);
                    }
                    ));
            }
            return expression;
        }

        /// <summary>
        /// Calculates given expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static string CalculateExpression(string expression)
        {
            string divisionPattern = @"([\d\,]+\/[\-]*[\d\,]+)";
            string multiplicationPattern = @"([\d\,]+\*[\-]*[\d\,]+)";
            string subtractionPattern = @"([\d\,]+\-[\-]*[\d\,]+)";
            string addPattern = @"([\d\,]+\+[\-]*[\d\,]+)";
            Regex regDivision = new Regex(divisionPattern, RegexOptions.Compiled);
            Regex regMultiplication = new Regex(multiplicationPattern, RegexOptions.Compiled);
            Regex regSubtraction = new Regex(subtractionPattern, RegexOptions.Compiled);
            Regex regAdd = new Regex(addPattern, RegexOptions.Compiled);
            
            expression = expression.Replace('.', ',');

            while (regDivision.IsMatch(expression) || regMultiplication.IsMatch(expression)||
                regSubtraction.IsMatch(expression)||regAdd.IsMatch(expression))
            {
                expression = regDivision.Replace(expression, new MatchEvaluator(
                    delegate(Match match)
                    {
                        string[] numbers = match.Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        double result = double.Parse(numbers[0]) / double.Parse(numbers[1]);
                        return result.ToString().Replace('.', ',');
                    }
                    ));
                expression = regMultiplication.Replace(expression, new MatchEvaluator(
                    delegate(Match match)
                    {
                        string[] numbers = match.Value.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                        double result = double.Parse(numbers[0]) * double.Parse(numbers[1]);
                        return result.ToString().Replace('.', ',');
                    }
                    ));
                expression = regSubtraction.Replace(expression, new MatchEvaluator(
                    delegate(Match match)
                    {
                        bool operationAdd = false;
                        if (match.Value.IndexOf("--") != -1)
                        {
                            operationAdd = true;
                        }
                        string[] numbers = match.Value.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        double result = 0;
                        if (operationAdd)
                        {
                            result = double.Parse(numbers[0]) + double.Parse(numbers[1]);
                        }
                        else
                        {
                            result = double.Parse(numbers[0]) - double.Parse(numbers[1]);
                        }
                        return result.ToString().Replace('.', ',');
                    }
                ));
                expression = regAdd.Replace(expression, new MatchEvaluator(
                    delegate(Match match)
                    {
                        string[] numbers = match.Value.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
                        double result = double.Parse(numbers[0]) + double.Parse(numbers[1]);
                        return result.ToString().Replace('.', ',');
                    }
                ));
            }
            return expression.Replace(',','.');
        }

        /// <summary>
        /// Calculates given arithmetical expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static string CalculateArithmeticalExpression(string expression)
        {
            expression = expression.Replace(" ", "");
            if (!CheckForCorrectBrackets(expression))
            {
                return "Wrong brackets in expression.";
            }
            expression = CalculateExpressionInFunctions(expression);
            if (badArithmeticExpression)
            {
                return "Wrong arithmetical expression.";
            }
            expression = CalculateExpressionInBrackets(expression);
            expression = CalculateExpression(expression);
            return expression;
        }

        /// <summary>
        /// Check brackets in arithmetical expression are correct.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static bool CheckForCorrectBrackets(string expression)
        {
            Stack<char> brackets = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    brackets.Push(expression[i]);
                }
                else if (expression[i] == ')')
                {
                    brackets.Pop();
                }
            }
            if (brackets.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            string result = CalculateArithmeticalExpression("(3 + 5.3) * 2.7 - ln(22) / pow(2.2,-1.7)"); //pow(2,3.14)*(3-(3*1-3.2)+1.5*0.3)
            Console.WriteLine("(3+5.3)*2.7-ln(22)/pow(2.2,-1.7) = {0}", result);
            result = CalculateArithmeticalExpression("pow(2,3.14)*(3-(3*sqrt(2)-3.2)+1.5*0.3)");
            Console.WriteLine("pow(2,3.14)*(3-(3*sqrt(2)-3.2)+1.5*0.3) = {0}",result);
        }
    }
}
