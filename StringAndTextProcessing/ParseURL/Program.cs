using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ParseURL
{
    class Program
    {
        /// <summary>
        /// Parse url and print result to console.
        /// </summary>
        /// <param name="url"></param>
        static void ParseUrl(string url)
        {
            string pattern = @"([\w]+)://([\w\s\d.]+)/([\w\s\W\d]+)";
            Regex regExpression = new Regex(pattern);

            Match match = regExpression.Match(url);

            Console.WriteLine("[protocol]=\"" + match.Groups[1].Value + "\"");
            Console.WriteLine("[server]=\"" + match.Groups[2].Value + "\"");
            Console.WriteLine("[resource]=\"" + match.Groups[3].Value + "\"");

        }

        static void Main(string[] args)
        {
            ParseUrl("http://www.devbg.org/forum/index.php");
        }
    }
}
