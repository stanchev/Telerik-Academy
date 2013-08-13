using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string : ");
            string inputString = Console.ReadLine();
            char[] chars = inputString.ToCharArray();
            Array.Reverse(chars);
            string reversedString = new string(chars);
            Console.WriteLine("Reversed string : {0}", reversedString);
        }
    }
}
