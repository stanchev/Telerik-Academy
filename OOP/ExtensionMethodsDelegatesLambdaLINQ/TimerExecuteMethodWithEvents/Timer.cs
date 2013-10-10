using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerExecuteMethodWithEvents
{
    public class Timer
    {
        public delegate void TimerEventHandler(object sender, TimerEventsArgs e);
        public delegate void KeyPressedEventHandler(object sender, KeyEventsArgs e);

        public event TimerEventHandler TimerEvent;
        public event KeyPressedEventHandler KeyPressedEvent;

        private volatile bool isRunning;
        private Thread newThread = null;
        public Timer()
        {
            this.isRunning = false;
        }

        private void CheckPressedKey()
        {
            Thread newThread = new Thread(() =>
            {
                while (this.isRunning)
                {
                    if (Console.KeyAvailable)
                    {
                        onKeyPressedEvent(new KeyEventsArgs(Console.ReadKey(true).KeyChar));
                    }
                    Thread.Sleep(1);
                }
            });
            newThread.Start();
        }

        public void Start(uint delay)
        {
            this.isRunning = true;
            this.CheckPressedKey();
            newThread = new Thread(() =>
                {
                    while (true)
                    {
                        onTimerEvent(new TimerEventsArgs(DateTime.Now));
                        Thread.Sleep((int)delay * 1000);
                    }
                });
            newThread.Start();
        }

        public void Stop()
        {
            this.isRunning = false;
            this.newThread.Abort();
        }

        protected void onTimerEvent(TimerEventsArgs e)
        {
            TimerEventHandler handler = TimerEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void onKeyPressedEvent(KeyEventsArgs e)
        {
            KeyPressedEventHandler handler = KeyPressedEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
