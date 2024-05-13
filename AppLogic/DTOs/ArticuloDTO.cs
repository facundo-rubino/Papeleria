using BussinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class ArticuloDTO
    {
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public int PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public ArticuloDTO() { }

        public ArticuloDTO(Articulo articulo)
        {
            if (articulo != null)
            {
                this.Nombre = articulo.Nombre;
                this.Descripcion = articulo.Descripcion;
                this.Codigo = articulo.Codigo;
                this.PrecioUnitario = articulo.PrecioUnitario;
                this.Stock = articulo.Stock;
            }
        }

    }



}
