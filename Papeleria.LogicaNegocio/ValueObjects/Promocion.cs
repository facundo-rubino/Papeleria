using System;
using Microsoft.EntityFrameworkCore;

namespace Papeleria.LogicaNegocio.ValueObjects
{
    [Owned]
    public class Promocion
    {

        public string Nombre { get; private set; }
        public int Valor { get; private set; }

        protected Promocion()
        {

        }
    }
}

