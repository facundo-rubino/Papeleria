using BussinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class ArticuloDTO
    {
        public int Id { get; private set; }
        [StringLength(200, MinimumLength = 10, ErrorMessage = "El nombre debe tener entre 10-200 caracteres")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El código debe ser de 13 dígitos")]
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
