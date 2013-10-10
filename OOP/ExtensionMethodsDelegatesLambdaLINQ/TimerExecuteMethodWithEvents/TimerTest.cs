using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerExecuteMethodWithEvents
{
    class TimerTest
    {
        static Timer timer = null;

        static void Main(string[] args)
        {
            timer = new Timer();
            timer.TimerEvent += timer_TimerEvent;
            timer.KeyPressedEvent += timer_KeyPressedEvent;
            timer.Start(3);

        }

        static void timer_KeyPressedEvent(object sender, KeyEventsArgs e)
        {
            if (e.PressedKey == 's')
            {
                timer.Stop();
            }
        }

        static void timer_TimerEvent(object sender, TimerEventsArgs e)
        {
            Console.WriteLine("If you want to stop press 'a'");
        }
    }
}
