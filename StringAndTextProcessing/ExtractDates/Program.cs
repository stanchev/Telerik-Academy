using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

namespace ExtractDates
{
    class Program
    {
        /// <summary>
        /// Return list of extracted date's.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static List<string> ExtractDatesFromText(string text)
        {
            string pattern = @"[\d]{1,2}\.[\d]{1,2}\.[\d]{4}";
            Regex regExpression = new Regex(pattern,RegexOptions.Compiled);
            List<string> dates = new List<string>();

            MatchCollection matches = regExpression.Matches(text);
            foreach (Match match in matches)
            {
                dates.Add(DateTime.Parse(match.Groups[0].Value).ToShortDateString());
            }
            return dates;
        }

        /// <summary>
        /// Print list of date's.
        /// </summary>
        /// <param name="dates"></param>
        static void PrinDates(List<string> dates)
        {
            foreach (string date in dates)
            {
                Console.WriteLine(date);
            }
        }

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string text = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";
            PrinDates(ExtractDatesFromText(text));
        }
    }
}
