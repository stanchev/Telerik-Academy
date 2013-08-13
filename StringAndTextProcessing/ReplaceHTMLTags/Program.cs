using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ReplaceHTMLTags
{
    class Program
    {
        /// <summary>
        /// Replace hyperlink tags and return new html.
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        static string ReplaceTags(string html)
        {
            string pattern = @"<a href=""([\w\s./:]+)"">([\w\s]+)</a>";
            Regex regExpression = new Regex(pattern,RegexOptions.Compiled);

            string replacedHTML = regExpression.Replace(html, "[URL=$1]$2[/URL]");

            return replacedHTML;
        }

        static void Main(string[] args)
        {
            string html = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
            Console.WriteLine(ReplaceTags(html));
        }
    }
}
