using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace ReadFile
{
    class Program
    {
        /// <summary>
        /// Read file content by given full path name.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static string ReadFileContent(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter full file path name (e.g. c:\\windows\\win.ini) : ");
            string fileName = Console.ReadLine();
            try
            {
                string fileContent = ReadFileContent(fileName);
                Console.WriteLine(fileContent);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("File path is too long.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied.");
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("No file path is given.");
            }
            catch (IOException)
            {
                Console.WriteLine("I/O error.Please try again");
            }
        }
    }
}
