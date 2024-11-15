using System;
using System.Runtime.Serialization;

namespace BusinessLogic.Excepciones
{
    public class PedidoNoValidoException : Exception
    {
        public PedidoNoValidoException()
        {
        }

        public PedidoNoValidoException(string? message) : base(message)
        {
        }

        public PedidoNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PedidoNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

