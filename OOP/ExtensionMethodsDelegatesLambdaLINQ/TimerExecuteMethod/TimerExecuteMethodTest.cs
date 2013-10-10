using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerExecuteMethod
{
    class TimerExecuteMethodTest
    {
        public static void PrintTime()
        {
            Console.WriteLine(DateTime.Now.ToLocalTime());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Press a to exit");
            Timer t = new Timer();
            t.Method = PrintTime;
            t.Start(1);
            while (Console.ReadKey(true).Key != ConsoleKey.A)
            {
                
            }
            t.Stop();
        }
    }
}
