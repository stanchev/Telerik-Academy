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
        static string divisionPattern = @"([\-]*[\d\,]+\/[\-]*[\d\,]+)";
        static string multiplicationPattern = @"([\-]*[\d\,]+\*[\-]*[\d\,]+)";
        static string subtractionPattern = @"([\-]*[\d\,]+\-[\-]*[\d\,]+)";
        static string addPattern = @"([\-]*[\d\,]+\+[\-]*[\d\,]+)";
        static Regex regDivision = new Regex(divisionPattern, RegexOptions.Compiled);
        static Regex regMultiplication = new Regex(multiplicationPattern, RegexOptions.Compiled);
        static Regex regSubtraction = new Regex(subtractionPattern, RegexOptions.Compiled);
        static Regex regAdd = new Regex(addPattern, RegexOptions.Compiled);

        static bool badArithmeticExpression = false;

        /// <summary>
        /// Calculates functions in given arithmetical expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static string CalculateExpressionInFunctions(string expression)
        {
            string functionsPattern = @"(sqrt\([\d\.\+\-\*\/\(\)]+\)\!)|(ln\([\d\.\+\-\*\/\(\)]+\)\!)|"+
                @"(pow\([\d\.\+\-\*\/\(\)]+\,[\d\.\+\-\*\/\(\)]+\)\!)";
            char[] symbols = new char[] { '+', '-', '*', '/' };
            Regex regFunctions = new Regex(functionsPattern, RegexOptions.Compiled);

            while (regFunctions.IsMatch(expression))
            {
                expression = regFunctions.Replace(expression, new MatchEvaluator(
                    delegate(Match match)
                    {
                        if (match.Value[0] == 's')
                        {
                            string sqrtFunction = string.Empty;
                            if (match.Value.IndexOfAny(symbols) == -1)
                            {
                                sqrtFunction = match.Value;
                            }
                            else
                            {
                                sqrtFunction = ParseExpressionInFunction(match.Value);
                            }
                            Match number = Regex.Match(sqrtFunction, @"[\-]*[\d\.]+");
                            double result = Math.Sqrt(Double.Parse(number.Value.Replace('.', ',')));
                            if (double.IsNaN(result))
                            {
                                badArithmeticExpression = true;
                            }
                            return result.ToString().Replace(',', '.');
                        }
                        else if (match.Value[0] == 'l')
                        {
                            string lnFunction = string.Empty;
                            if (match.Value.IndexOfAny(symbols) == -1)
                            {
                                lnFunction = match.Value;
                            }
                            else
                            {
                                lnFunction = ParseExpressionInFunction(match.Value);
                            }
                            Match number = Regex.Match(lnFunction, @"[\-]*[\d\.]+");
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
                            powFunction = powFunction.Remove(powFunction.Length - 2, 2);
                            string[] expressions = powFunction.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < expressions.Length; i++)
                            {
                                if (expressions[i].IndexOfAny(symbols) != -1)
                                {
                                    expressions[i] = ParseExpressionInFunction(expressions[i]);
                                }                           
                            }
                            double result = Math.Pow(double.Parse(
                                expressions[0].Replace('.', ',')), double.Parse(expressions[1].Replace('.', ',')));
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
            expression = expression.Replace('.', ',');

            while (regDivision.IsMatch(expression) || regMultiplication.IsMatch(expression) ||
                regSubtraction.IsMatch(expression) || regAdd.IsMatch(expression))
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
                        string substraction = match.Value;
                        bool isFirstSignMinus = false;
                        if (substraction[0] == '-')
                        {
                            isFirstSignMinus = true;
                        }
                        bool operationAdd = false;
                        if (substraction.IndexOf("--") != -1)
                        {
                            operationAdd = true;
                        }
                        string[] numbers = substraction.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (isFirstSignMinus)
                        {
                            numbers[0] = "-" + numbers[0];
                        }
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
            return expression.Replace(',', '.');
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
            expression = AddEndOfFunctions(expression);
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
            int bracketsCount = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    bracketsCount++;
                }
                else if (expression[i] == ')')
                {
                    bracketsCount--;
                }
            }
            if (bracketsCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Parse expression inside function.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static string ParseExpressionInFunction(string expression)
        {
            int count = 0;
            switch (expression[0])
            {
                case 'l': count = 3; break;
                case 's': count = 5; break;
            }
            if (count != 0)
            {
                expression = expression.Remove(0, count);
                expression = expression.Remove(expression.Length - 2, 2);                
            }
            expression = CalculateExpressionInBrackets(expression);
            expression = CalculateExpression(expression);
            return expression;
        }

        /// <summary>
        /// Add sign for end of function.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static string AddEndOfFunctions(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                int index = 0;
                switch (expression[i])
                {
                    case 'l':
                        index = GetIndexOfClosingBracket(i + 2, expression);
                        expression = expression.Insert(index, "!");
                        break;
                    case 's':
                        index = GetIndexOfClosingBracket(i + 4, expression);
                        expression = expression.Insert(index, "!");
                        break;
                    case 'p':
                        index = GetIndexOfClosingBracket(i + 3, expression);
                        expression = expression.Insert(index, "!");
                        break;
                }
            }
            return expression;
        }

        /// <summary>
        /// Get index of closing brackets.Return index of closes bracket of function.
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        static int GetIndexOfClosingBracket(int startIndex,string expression)
        {
            int countOfBrackets = 1;
            int index = 0;
            for (int i = startIndex + 1; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    countOfBrackets++;
                }
                else if(expression[i] == ')')
                {
                    countOfBrackets--;
                    if (countOfBrackets == 0)
                    {
                        index = i + 1;
                        break;
                    }
                }
            }
            return index;
        }

        static void Main(string[] args)
        {
            string result = CalculateArithmeticalExpression("(3+5.3)*2.7-ln(22)/pow(2.2,-1.7)");
            Console.WriteLine("(3+5.3)*2.7-ln(22)/pow(2.2,-1.7) = {0}", result);
            result = CalculateArithmeticalExpression("pow(2,3.14)*(3-(3*sqrt(2)-3.2)+1.5*0.3)");
            Console.WriteLine("pow(2,3.14)*(3-(3*sqrt(2)-3.2)+1.5*0.3) = {0}", result);
        }
    }
}
