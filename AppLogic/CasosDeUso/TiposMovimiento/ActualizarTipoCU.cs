using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.TiposMovimiento;
using AppLogic.Mappers;
using BusinessLogic.Entidades;
using BusinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.TiposMovimiento
{
    public class ActualizarTipoCU : IActualizarTipo
    {
        private IRepositorioTiposMovimiento _repositorioTiposMovimiento;
        private IRepositorioMovimientos _repositorioMovimientos;

        public ActualizarTipoCU(
            IRepositorioTiposMovimiento repositorioTiposMovimiento,
            IRepositorioMovimientos repositorioMovimientos)
        {
            this._repositorioTiposMovimiento = repositorioTiposMovimiento;
            this._repositorioMovimientos = repositorioMovimientos;

        }

        public void ActualizarTipo(TipoMovimientoDTO tipoMovimientoDTO)
        {
            if (this._repositorioMovimientos.TipoMovimientoEnUso(tipoMovimientoDTO.Id))
                throw new Exception("El tipo de movimiento con el id " + tipoMovimientoDTO.Id + " está en uso");
            this._repositorioTiposMovimiento.Update(TipoMovimientoDTOMapper.FromDto(tipoMovimientoDTO));
        }


    }
}

