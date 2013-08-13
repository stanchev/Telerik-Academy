using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExtractFromHTML
{
    class Program
    {
        /// <summary>
        /// Read html content from file by given path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static string ReadHTML(string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// Get content of html tag.
        /// </summary>
        /// <param name="htmlTag"></param>
        /// <returns></returns>
        static string GetContent(string htmlTag)
        {
            StringBuilder content = new StringBuilder();
            for (int i = 0; i < htmlTag.Length; i++)
            {
                StringBuilder text = new StringBuilder();
                if (htmlTag[i] == '>')
                {
                    for (int j = i + 1; j < htmlTag.Length; j++)
                    {
                        if (htmlTag[j] != '<')
                        {
                            text.Append(htmlTag[j]);
                        }
                        else if (htmlTag[j] == '<')
                        {
                            i = j + 1;
                            break;
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(text.ToString()))
                {
                    content.AppendLine(text.ToString().Trim());
                }
            }
            return content.ToString();
        }

        /// <summary>
        /// Print title and body text of given html.
        /// </summary>
        /// <param name="html"></param>
        static void PrintTitleAndBody(string html)
        {
            int startTitle = html.IndexOf("<title>");
            int endTitle = html.IndexOf("</title>") + "</title>".Length;
            string title = html.Substring(startTitle, endTitle - startTitle);
            int startBody = html.IndexOf("<body>");
            int endBody= html.IndexOf("</body>") + "</body>".Length;
            string body = html.Substring(startBody, endBody - startBody);
            
            Console.WriteLine("Title : {0}",GetContent(title));
            Console.WriteLine("Body : {0}",GetContent(body));
        }

        static void Main(string[] args)
        {
            string html = ReadHTML("index.html");
            PrintTitleAndBody(html);
        }
    }
}
