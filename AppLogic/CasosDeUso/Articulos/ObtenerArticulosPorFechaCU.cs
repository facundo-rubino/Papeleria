using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Articulos;
using AppLogic.Mappers;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Articulos
{
    public class ObtenerArticulosPorFechaCU : IArticulosPorFecha
    {
        private IRepositorioArticulos _repositorioArticulos;
        public ObtenerArticulosPorFechaCU(IRepositorioArticulos repositorioArticulos)
        {
            this._repositorioArticulos = repositorioArticulos;
        }

        public IEnumerable<ArticuloDTO> ArticulosPorFecha(DateTime fechaIni, DateTime fechaFin)
        {
            return this._repositorioArticulos.GetArticulosPorMovimientoFecha(fechaIni, fechaFin)
                .Select(articulo => ArticuloDTOMapper.ToDto(articulo)); ;
        }
    }
}

