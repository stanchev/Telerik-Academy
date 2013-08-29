using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidRangeCheck
{
    [Serializable]
    public class InvalidRangeException<T> : Exception
    {
        public T MinValue { get; private set; }
        public T MaxValue { get; private set; }

        public InvalidRangeException(string message, T start, T end)
            : base(message)
        {
            this.MinValue = start;
            this.MaxValue = end;
        }
        public InvalidRangeException(string message, T start, T end, Exception inner)
            : base(message)
        {
            this.MinValue = start;
            this.MaxValue = end;
        }

        protected InvalidRangeException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        public override string ToString()
        {
            string exceptionInfo = string.Format("{0}.Valid range is [{1}..{2}].",
                base.Message, this.MinValue, this.MaxValue);
            return exceptionInfo;
        }
    }
}
