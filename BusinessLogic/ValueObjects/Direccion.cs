using System;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.ValueObjects
{
    [Owned]
    public class Direccion
    {
        public string Calle { get; private set; }
        public string Numero { get; private set; }
        public string Ciudad { get; private set; }
        public double Distancia { get; private set; }

        protected Direccion()
        {
        }
    }
}

