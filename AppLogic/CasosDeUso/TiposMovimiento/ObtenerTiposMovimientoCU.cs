using AppLogic.DTOs;
using AppLogic.InterfacesCU.TiposMovimiento;
using AppLogic.Mappers;
using BusinessLogic.Entidades;
using BusinessLogic.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.CasosDeUso.TiposMovimiento
{
    public class ObtenerTiposMovimientoCU : IObtenerTipos
    {
        private IRepositorioTiposMovimiento _repositorioTiposMovimiento;

        public ObtenerTiposMovimientoCU(IRepositorioTiposMovimiento repositorioTiposMovimiento)
        {
            this._repositorioTiposMovimiento = repositorioTiposMovimiento;
        }

        public IEnumerable<TipoMovimientoDTO> ObtenerTiposMovimiento()
        {
            return this._repositorioTiposMovimiento.FindAll().Select(TipoMovimiento => TipoMovimientoDTOMapper.ToDto(TipoMovimiento));
        }
    }
}
