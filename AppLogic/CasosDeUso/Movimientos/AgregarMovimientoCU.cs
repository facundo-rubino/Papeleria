using AppLogic.DTOs;
using AppLogic.InterfacesCU.Movimientos;
using AppLogic.Mappers;
using BusinessLogic.Entidades;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.CasosDeUso.Movimientos
{
    public class AgregarMovimientoCU : IAgregarMovimiento
    {
        private IRepositorioMovimientos _repositorioMovimientos;

        public AgregarMovimientoCU(IRepositorioMovimientos repositorioMovimientos)
        {
            this._repositorioMovimientos = repositorioMovimientos;
        }

        public void AgregarMovimiento(MovimientoDTO aAgregar)
        {
            Movimiento movimiento = MovimientoDTOMapper.FromDto(aAgregar);
            this._repositorioMovimientos.Add(movimiento);
        }
    }
}
