using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Movimientos;
using AppLogic.Mappers;
using BusinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Movimientos
{
    public class ObtenerMovimientosCU : IObtenerMovimientos
    {
        private IRepositorioMovimientos _repositorioMovimientos;

        public ObtenerMovimientosCU(IRepositorioMovimientos repositorioMovimientos)
        {
            this._repositorioMovimientos = repositorioMovimientos;
        }

        public IEnumerable<MovimientoDTO> ObtenerMovimientos()
        {
            return this._repositorioMovimientos.FindAll().Select(Movimiento => MovimientoDTOMapper.ToDto(Movimiento));
        }
    }
}

