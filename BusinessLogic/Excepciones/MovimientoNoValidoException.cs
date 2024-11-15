using System;
using System.Runtime.Serialization;

namespace BusinessLogic.Excepciones
{
    public class MovimientoNoValidoException : Exception
    {
        public MovimientoNoValidoException()
        {
        }

        public MovimientoNoValidoException(string? message) : base(message)
        {
        }

        public MovimientoNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MovimientoNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}

