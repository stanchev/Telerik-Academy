using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerExecuteMethod
{
    class Timer
    {
        public delegate void RunMethod();

        public RunMethod Method { get; set; }
        private Thread newThread;
        private volatile bool isRunning;

        private void PrintExecutesTime()
        {
            Console.WriteLine("Delegate invoked : {0}",DateTime.Now.ToLocalTime());
        }

        public Timer()
        {
            this.Method = PrintExecutesTime;
            this.newThread = null;
            this.isRunning = false;
        }

        public void Start(uint delay)
        {
            this.isRunning = true;
            this.newThread = new Thread(() =>
            {
                while (this.isRunning)
                {
                    this.Method.Invoke();
                    Thread.Sleep((int)delay * 1000);
                }
            });
            this.newThread.Start();
        }

        public void Stop()
        {
            this.isRunning = false;
        }
    }
}
