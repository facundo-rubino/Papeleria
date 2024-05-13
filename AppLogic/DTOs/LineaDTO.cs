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
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }

        public LineaDTO()
        {
        }

        public LineaDTO(Linea linea)
        {
            if (linea != null)
            {
                this.Id = linea.Id;
                this.Articulo = linea.Articulo;
                this.Cantidad = linea.Cantidad;
                this.Precio = linea.Precio;
            }
        }
    }
}
