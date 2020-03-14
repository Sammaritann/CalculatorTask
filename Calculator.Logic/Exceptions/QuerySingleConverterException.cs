using System;
using System.Runtime.Serialization;

namespace Calculator.Logic.Exceptions
{
    [Serializable]
    public class QuerySingleConverterException : QueryException
    {
        public QuerySingleConverterException()
        {
        }

        public QuerySingleConverterException(string message)
            : base(message)
        {
        }

        public QuerySingleConverterException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected QuerySingleConverterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}