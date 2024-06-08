using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.TiposMovimiento;
using AppLogic.Mappers;
using BusinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.TiposMovimiento
{
    public class ObtenerTipoPorIdCU : IObtenerTipoPorId
    {

        private IRepositorioTiposMovimiento _repositorioTiposMovimiento;

        public ObtenerTipoPorIdCU(IRepositorioTiposMovimiento repositorioTiposMovimiento)
        {
            this._repositorioTiposMovimiento = repositorioTiposMovimiento;
        }

        public TipoMovimientoDTO GetTipoPorId(int id)
        {
            return TipoMovimientoDTOMapper.ToDto(this._repositorioTiposMovimiento.FindByID(id));
        }
    }
}

