using System;
using Microsoft.EntityFrameworkCore;
using BussinessLogic.Excepciones;

namespace BussinessLogic.ValueObjects
{
    [Owned]
    public class NombreCompleto
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }

        public NombreCompleto(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            EsValido();
        }

        protected NombreCompleto()
        {
            this.Nombre = "Sin nombre";
            this.Apellido = "Sin apellido";
        }

        public void EsValido()
        {
            if (String.IsNullOrEmpty(this.Apellido)) throw new UsuarioNoValidoException("El apellido no puede estar vacío");
            if (String.IsNullOrEmpty(this.Nombre)) throw new UsuarioNoValidoException("El nombre no puede estar vacío");
        }

    }
}

