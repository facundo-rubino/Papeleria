using BussinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class LineaDTO
    {
        public int Id { get; private set; }
        [ForeignKey(nameof(Articulo))] public int ArticuloId { get; set; }
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
                this.ArticuloId = linea.ArticuloId;
                this.Cantidad = linea.Cantidad;
                this.Precio = linea.Precio;
            }
        }
    }
}
