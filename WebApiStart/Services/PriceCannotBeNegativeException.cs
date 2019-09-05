using System;
using System.Runtime.Serialization;

namespace WebApiStart.View
{
    [Serializable]
    internal class PriceCannotBeNegativeException : Exception
    {
        public PriceCannotBeNegativeException()
        {
        }

        public PriceCannotBeNegativeException(string message) : base(message)
        {
        }

        public PriceCannotBeNegativeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PriceCannotBeNegativeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}