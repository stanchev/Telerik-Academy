using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace DateAfterHoursAndMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write("Enter date and time [day.month.year hour:minute:second] : ");
                DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                CultureInfo k = new CultureInfo("bg-BG");
                Console.WriteLine("\n" + dateTime.AddHours(6.5).ToString("dddd dd.MM.yyyy HH:mm:ss", k));
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format");
            }
        }
    }
}
