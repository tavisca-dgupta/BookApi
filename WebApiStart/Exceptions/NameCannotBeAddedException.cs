using System;
using System.Runtime.Serialization;

namespace WebApiStart.View
{
    [Serializable]
    internal class NameCannotBeAddedException : Exception
    {
        public NameCannotBeAddedException()
        {

        }

        public NameCannotBeAddedException(string message) : base(message)
        {
        }

        public NameCannotBeAddedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameCannotBeAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}