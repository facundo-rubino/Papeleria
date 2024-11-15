using System;
using System.Runtime.Serialization;

namespace BussinessLogic.Excepciones
{
    public class RolNoValidoException : Exception
    {
        public RolNoValidoException()
        {
        }

        public RolNoValidoException(string? message) : base(message)
        {
        }

        public RolNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RolNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

