using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UppercaseText
{
    class Program
    {
        /// <summary>
        /// Return text and make uppercase text in tag.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string ReturnUppercaseTagsText(string text)
        {
            string pattern = @"<upcase>([\w\s]+)</upcase>";
            Regex regExpression = new Regex(pattern);

            string newText = regExpression.Replace(text, m => string.Format("{0}", m.Groups[1].Value.ToUpper()));
            return newText;
        }

        static void Main(string[] args)
        {
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            Console.WriteLine(ReturnUppercaseTagsText(text));
        }
    }
}
