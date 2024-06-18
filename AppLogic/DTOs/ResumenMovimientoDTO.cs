using System;
namespace AppLogic.DTOs
{
    public class ResumenMovimientoDTO
    {
        public int Anio { get; set; }
        public DetalleMovimientoDTO[] Detalles { get; set; }
        public int TotalAnio { get; set; }

        public ResumenMovimientoDTO()
        {
        }
    }
}

