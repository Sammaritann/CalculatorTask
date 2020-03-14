using System;
using System.Runtime.Serialization;

namespace Calculator.Logic.Exceptions
{
    [Serializable]
    public class CurrencyFormatException : QueryException
    {
        public CurrencyFormatException()
        {
        }

        public CurrencyFormatException(string message)
            : base(message)
        {
        }

        public CurrencyFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected CurrencyFormatException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}