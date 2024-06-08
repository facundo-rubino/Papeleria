using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.TiposMovimiento;
using AppLogic.Mappers;
using BusinessLogic.Entidades;
using BusinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.TiposMovimiento
{
    public class AgregarTipoMovimientoCU : IAgregarTipo
    {
        private IRepositorioTiposMovimiento _repositorioTiposMovimiento;

        public AgregarTipoMovimientoCU(IRepositorioTiposMovimiento repositorioTiposMovimiento)
        {
            this._repositorioTiposMovimiento = repositorioTiposMovimiento;
        }

        public void AgregarTipo(TipoMovimientoDTO aAgregar)
        {
            TipoMovimiento tipo = TipoMovimientoDTOMapper.FromDto(aAgregar);
            this._repositorioTiposMovimiento.Add(tipo);
        }
    }
}

