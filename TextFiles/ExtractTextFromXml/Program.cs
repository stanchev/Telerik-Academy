using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExtractTextFromXml
{
    class Program
    {
        /// <summary>
        /// Extract text from xml file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static string GetTextFormXmlFile(string path)
        {
            string fileContent = null;
            using (TextReader read = new StreamReader(path))
            {
                fileContent = read.ReadToEnd();
            }
            StringBuilder xmlTextContent = new StringBuilder();
            for (int i = 0; i < fileContent.Length; i++)
            {
                StringBuilder word = new StringBuilder();
                if (fileContent[i] == '>')
                {
                    for (int j = i + 1; j < fileContent.Length; j++)
                    {
                        if (fileContent[j] != '<')
                        {
                            word.Append(fileContent[j]);
                        }
                        else if (fileContent[j] == '<')
                        {
                            i = j + 1;
                            break;
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(word.ToString()))
                {
                    xmlTextContent.AppendLine(word.ToString().Trim());                    
                }
            }
            return xmlTextContent.ToString();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter path to text file : ");
            string filePath = Console.ReadLine();
            try
            {
                Console.WriteLine(GetTextFormXmlFile(filePath));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
