using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Movimientos
{
    public interface IMovimientoPorArticuloTipo
    {
        public IEnumerable<MovimientoDTO> GetMovimientosPorArticuloTipo(int articuloId, int tipoId);
    }
}

