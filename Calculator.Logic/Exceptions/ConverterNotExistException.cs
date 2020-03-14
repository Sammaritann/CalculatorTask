using System;
using System.Runtime.Serialization;

namespace Calculator.Logic.Exceptions
{
    [Serializable]
    public class ConverterNotExistException : QueryException
    {
        public ConverterNotExistException()
        {
        }

        public ConverterNotExistException(string message)
            : base(message)
        {
        }

        public ConverterNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ConverterNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}