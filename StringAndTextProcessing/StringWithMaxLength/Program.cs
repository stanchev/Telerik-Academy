using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringWithMaxLength
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = null;
            do
            {
                Console.Write("Enter text(max 20 characters) : ");
                text = Console.ReadLine();
            } while (text.Length > 20);

            for (int i = text.Length; i < 20; i++)
            {
                text += "*";
            }
            Console.WriteLine(text);
        }
    }
}
