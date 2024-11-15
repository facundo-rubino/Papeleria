using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Movimientos
{
    public interface IObtenerAgrupados
    {
        public IEnumerable<ResumenMovimientoDTO> GetResumenMovimientos();

    }

}

