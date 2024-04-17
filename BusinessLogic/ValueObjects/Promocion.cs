using System;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.ValueObjects
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

