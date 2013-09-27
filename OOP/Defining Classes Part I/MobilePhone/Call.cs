using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    class Call
    {
        private DateTime startDateTime;
        private DateTime endDateTime;
        private string dialedNumber;

        public string Date
        {
            get
            {
                return this.startDateTime.ToShortDateString();
            }
        }

        public string Time
        {
            get
            {
                return this.startDateTime.ToShortTimeString();
            }
        }

        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }
        }

        public double Duration
        {
            get
            {
                return (this.endDateTime - this.startDateTime).TotalSeconds;
            }
        }

        public Call(DateTime startDateTime, DateTime endDateTime, string dialedNumber)
        {
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.dialedNumber = dialedNumber;
        }

        public override string ToString()
        {
            string callInfo = string.Format("Number: {0}\nDate: {1}\nTime: {2}\nDuration: {3} seconds",
                this.DialedNumber,this.Date,this.Time,this.Duration);
            return callInfo;
        }
    }
}
