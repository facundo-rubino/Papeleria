using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.Entidades
{
    public class Linea
    {
        public int Id { get; private set; }
        public Articulo Articulo { get; private set; }
        public int Precio { get; private set; }
        public int Cantidad { get; private set; }

        public Linea()
        {
        }
    }
}

