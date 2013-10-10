using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerExecuteMethodWithEvents
{
    public class KeyEventsArgs : EventArgs
    {
        public char PressedKey { get; private set; }

        public KeyEventsArgs(char pressedKey)
        {
            this.PressedKey = pressedKey;
        }
    }
}
