using BusinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class TipoMovimientoDTO
    {
        public int Id { get; private set; }
        public string Nombre { get; set; }

        public TipoMovimientoDTO()
        {
        }
        public TipoMovimientoDTO(TipoMovimiento tipoMovimiento)
        {
            this.Id = tipoMovimiento.Id;
            this.Nombre = tipoMovimiento.Nombre;
        }
    }
}
