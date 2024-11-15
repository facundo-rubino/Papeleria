using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.TiposMovimiento
{
    public interface IObtenerTipoPorId
    {
        public TipoMovimientoDTO GetTipoPorId(int id);
    }
}

