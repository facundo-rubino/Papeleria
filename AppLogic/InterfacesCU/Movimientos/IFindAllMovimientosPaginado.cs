using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Movimientos
{
    public interface IFindAllMovimientosPaginado
    {
        public IEnumerable<MovimientoDTO> FindAllPaginado(int pag);
    }
}

