using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerExecuteMethodWithEvents
{
    public class TimerEventsArgs : EventArgs
    {
        public DateTime Time { get; private set; }

        public TimerEventsArgs(DateTime time)
        {
            this.Time = time;
        }
    }
}
