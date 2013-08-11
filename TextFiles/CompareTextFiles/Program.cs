using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompareTextFiles
{
    class Program
    {
        /// <summary>
        /// Compare two text files with same line counts and return count of same and different lines. 
        /// </summary>
        /// <param name="firstFilePath"></param>
        /// <param name="secondFilePath"></param>
        /// <returns></returns>
        static string CompareFiles(string firstFilePath, string secondFilePath)
        {
            StringBuilder compareResult = new StringBuilder();
            using (TextReader firstFile = new StreamReader(firstFilePath), secondFile = new StreamReader(secondFilePath))
            {
                compareResult.AppendLine("Lines result:");
                string firstFileLine = null, secondFileLine = null;
                int lineCount = 0, sameLineCount = 0;
                while ((firstFileLine = firstFile.ReadLine()) != null)
                {
                    lineCount++;
                    secondFileLine = secondFile.ReadLine();
                    if (firstFileLine.Equals(secondFileLine))
                    {
                        compareResult.AppendLine(lineCount + "  =  " + lineCount);
                        sameLineCount++;
                    }
                    else
                    {
                        compareResult.AppendLine(lineCount + "  !=  " + lineCount);
                    }
                }
                compareResult.AppendLine("Count of same line : " + sameLineCount);
                compareResult.AppendLine("Count of different line : " + (lineCount - sameLineCount));
            }

            return compareResult.ToString();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter path to first text file : ");
            string firstFilePath = Console.ReadLine();
            Console.Write("Enter path to second text file : ");
            string secondFilePath = Console.ReadLine();
            try
            {
                Console.WriteLine(CompareFiles(firstFilePath, secondFilePath));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
