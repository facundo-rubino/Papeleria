using System;
using System.Runtime.Serialization;

namespace BussinessLogic.Excepciones
{
    public class ArticuloNoValidoException : Exception
    {
        public ArticuloNoValidoException()
        {
        }

        public ArticuloNoValidoException(string? message) : base(message)
        {
        }

        public ArticuloNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ArticuloNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

