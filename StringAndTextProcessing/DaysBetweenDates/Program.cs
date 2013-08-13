using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DaysBetweenDates
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter first date [day.month.year] : ");
                DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
                Console.Write("Enter second date [day.month.year] : ");
                DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine("Distance : {0}", (secondDate - firstDate).Days);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format");
            }
        }
    }
}
