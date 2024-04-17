using System;
using System.Runtime.Serialization;

namespace Papeleria.LogicaNegocio.Excepciones
{
    public class UsuarioNoValidoException : Exception
    {
        public UsuarioNoValidoException()
        {
        }

        public UsuarioNoValidoException(string? message) : base(message)
        {
        }

        public UsuarioNoValidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsuarioNoValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

