using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Movimientos;
using AppLogic.Mappers;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Movimientos
{
    public class FindAllMovimientosPaginadoCU : IFindAllMovimientosPaginado
    {
        private IRepositorioMovimientos _repositorioMovimientos;
        private IRepositorioSettings _repositorioSettings;
        public FindAllMovimientosPaginadoCU(
            IRepositorioMovimientos repositorioMovimientos,
            IRepositorioSettings repositorioSettings)
        {
            this._repositorioMovimientos = repositorioMovimientos;
            this._repositorioSettings = repositorioSettings;
        }

        public IEnumerable<MovimientoDTO> FindAllPaginado(int pag)
        {
            int size = int.Parse(this._repositorioSettings.GetValueByName("PagSize") + "");
            return this._repositorioMovimientos.FindAllPaginado(pag, size).Select(Movimiento => MovimientoDTOMapper.ToDto(Movimiento));
        }


    }
}

