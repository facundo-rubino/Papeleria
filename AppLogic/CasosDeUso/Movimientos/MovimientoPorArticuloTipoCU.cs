using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Movimientos;
using AppLogic.Mappers;
using BusinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Movimientos
{
    public class MovimientoPorArticuloTipoCU : IMovimientoPorArticuloTipo
    {

        private IRepositorioMovimientos _repositorioMovimientos;

        public MovimientoPorArticuloTipoCU(IRepositorioMovimientos repositorioMovimientos)
        {
            this._repositorioMovimientos = repositorioMovimientos;
        }

        public IEnumerable<MovimientoDTO> GetMovimientosPorArticuloTipo(int articuloId, int tipoId)
        {
            return this._repositorioMovimientos.GetMovimientosPorArticuloTipo(articuloId, tipoId)
          .Select(mov => MovimientoDTOMapper.ToDto(mov));
        }
    }
}

