using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.Entidades
{
    public class Linea
    {
        public int Id { get; private set; }
        [ForeignKey(nameof(Articulo))] public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

        public Linea()
        {
        }
    }
}

