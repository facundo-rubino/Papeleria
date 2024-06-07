using System;
using BussinessLogic.Entidades;

namespace BusinessLogic.Entidades
{
    public class MovimientoStock
    {
        public int Id { get; private set; }
        public DateTime FechaHora { get; set; }
        public Articulo Articulo { get; set; }
        public int Cant { get; set; }

        public MovimientoStock()
        {
        }
    }
}

