using System;
namespace AppLogic.DTOs
{
    public class ResumenMovimientoDTO
    {
        public int Anio { get; set; }
        public DetalleMovimientoDTO[] Detalles { get; set; }
        public int TotalAño { get; set; }

        public ResumenMovimientoDTO()
        {
        }
    }
}

