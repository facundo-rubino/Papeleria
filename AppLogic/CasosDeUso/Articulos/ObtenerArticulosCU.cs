using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Articulos;
using AppLogic.Mappers;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Articulos
{
    public class ObtenerArticulosCU : IObtenerArticulos
    {
        private IRepositorioArticulos _repositorioArticulos;
        public ObtenerArticulosCU(IRepositorioArticulos repositorioArticulos)
        {
            this._repositorioArticulos = repositorioArticulos;
        }
        public IEnumerable<ArticuloDTO> ObtenerArticulos()
        {
            return this._repositorioArticulos.FindAll().Select(articulo => ArticuloDTOMapper.ToDto(articulo));
        }
    }
}

