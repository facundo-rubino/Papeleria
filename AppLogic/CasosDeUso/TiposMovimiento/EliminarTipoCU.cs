using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.TiposMovimiento;
using AppLogic.Mappers;
using BusinessLogic.Entidades;
using BusinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.TiposMovimiento
{
    public class EliminarTipoCU : IEliminarTipo
    {
        private IRepositorioTiposMovimiento _repositorioTiposMovimiento;
        private IRepositorioMovimientos _repositorioMovimientos;

        public EliminarTipoCU(
            IRepositorioTiposMovimiento repositorioTiposMovimiento,
            IRepositorioMovimientos repositorioMovimientos)
        {
            this._repositorioTiposMovimiento = repositorioTiposMovimiento;
            this._repositorioMovimientos = repositorioMovimientos;
        }

        public void DeleteTipo(int tipoMovimientoId)
        {
            if (this._repositorioMovimientos.TipoMovimientoEnUso(tipoMovimientoId))
                throw new Exception("El tipo de movimiento con el id " + tipoMovimientoId + " está en uso");
            this._repositorioTiposMovimiento.Remove(tipoMovimientoId);
        }
    }
}

