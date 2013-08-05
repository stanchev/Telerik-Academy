using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDays
{
    class Program
    {
        static DateTime[] WorkSaturdays = { new DateTime(2013, 05, 11), new DateTime(2013, 12, 14) };

        static DateTime[] FeirTags = { new DateTime(2013, 01, 01), new DateTime(2013, 03, 03),
                                       new DateTime(2013, 05, 01), new DateTime(2013, 05, 02),
                                       new DateTime(2013, 05, 03), new DateTime(2013, 05, 04),
                                       new DateTime(2013, 05, 05), new DateTime(2013, 05, 06),
                                       new DateTime(2013, 05, 24), new DateTime(2013, 09, 06),
                                       new DateTime(2013, 09, 22), new DateTime(2013, 12, 24),
                                       new DateTime(2013, 12, 25), new DateTime(2013, 12, 26),
                                       new DateTime(2013, 12, 31)
                                     };

        static void Main(string[] args)
        {
            Console.Write("Enter end of work day (DD/MM/YYYY) : ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            if (endDate < DateTime.Today)
            {
                Console.WriteLine("Enter date after today.");
            }
            else
            {
                endDate = endDate.AddDays(1);
                int days = endDate.Subtract(DateTime.Now).Days;
                int count = 0;
                for (int i = 1; i <= days; i++)
                {
                    DateTime cuurentDay = DateTime.Now.AddDays(i);
                    if (cuurentDay.DayOfWeek.ToString() != "Sunday")
                    {
                        if (cuurentDay.DayOfWeek.ToString() == "Saturday")
                        {
                            foreach (DateTime item in WorkSaturdays)
                            {
                                if (cuurentDay.Date == item)
                                {
                                    count++;
                                }
                            }
                        }
                        else
                        {
                            bool isFeirTag = false;
                            foreach (DateTime item in FeirTags)
                            {
                                if (cuurentDay.Date == item)
                                {
                                    isFeirTag = true;
                                    break;
                                }
                            }
                            if (!isFeirTag)
                            {
                                count++;
                            }
                        }
                    }
                }
                Console.WriteLine("{0} days, works {1}", days, count);
            }
        }
    }
}
