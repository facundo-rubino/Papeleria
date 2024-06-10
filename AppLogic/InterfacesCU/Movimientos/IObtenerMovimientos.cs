using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Movimientos
{
    public interface IObtenerMovimientos
    {
        public IEnumerable<MovimientoDTO> ObtenerMovimientos();

    }
}

