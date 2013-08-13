using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExtractMails
{
    class Program
    {
        /// <summary>
        /// Return list of e-mails addresses in given text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static List<string> ExtractMailsFromText(string text)
        {
            string patern = @"[\w._]+@[\w-.]+\.[\w]{2,3}";
            Regex regExpression = new Regex(patern, RegexOptions.Compiled);
            List<string> mails = new List<string>();

            MatchCollection matches = regExpression.Matches(text);   //[\w.]+
            foreach (Match match in matches)
            {
                mails.Add(match.Groups[0].Value);
            }
            return mails;
        }

        static void PrinEmails(List<string> mails)
        {
            foreach (string mail in mails)
            {
                Console.WriteLine(mail);
            }
        }

        static void Main(string[] args)
        {
            string text = "Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";
            PrinEmails(ExtractMailsFromText(text));
        }
    }
}
