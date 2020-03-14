using System;
using System.Runtime.Serialization;

namespace Calculator.Logic.Exceptions
{
    [Serializable]
    public class QueryException : Exception
    {
        public QueryException()
        {
        }

        public QueryException(string message)
            : base(message)
        {
        }

        public QueryException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected QueryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}