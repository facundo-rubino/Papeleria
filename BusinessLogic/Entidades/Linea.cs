using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.Entidades
{
    public class Linea
    {
        public int Id { get; private set; }
        public Articulo Articulo { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

        public Linea()
        {
        }

        public Linea(int id, Articulo articulo, int precio, int cantidad)
        {
            this.Id = id;
            this.Articulo = articulo;
            this.Precio = precio;
            this.Cantidad = cantidad;
        }
    }
}

