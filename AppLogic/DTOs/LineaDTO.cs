using BussinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class LineaDTO
    {
        public int Id { get; private set; }
        public Articulo Articulo { get; private set; }
        public int Precio { get; private set; }
        public int Cantidad { get; private set; }

        public LineaDTO()
        {
        }

        public LineaDTO(Linea linea)
        {
            if (linea != null)
            {
                this.Id = linea.Id;
                this.Articulo = linea.Articulo;
                this.Precio = linea.Precio;
                this.Cantidad = linea.Cantidad;
            }
        }
}
}
