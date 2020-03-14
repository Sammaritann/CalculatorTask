using System;
using System.Runtime.Serialization;

namespace Calculator.Logic.Exceptions
{
    public class ConvertException : Exception
    {
        public ConvertException()
        {
        }

        public ConvertException(string message)
            : base(message)
        {
        }

        public ConvertException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ConvertException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}