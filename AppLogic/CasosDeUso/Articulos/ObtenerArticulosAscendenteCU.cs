using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Articulos;
using AppLogic.Mappers;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Articulos
{
    public class ObtenerArticulosAscendenteCU : IObtenerArticulosAscendente
    {
        private IRepositorioArticulos _repositorioArticulos;
        public ObtenerArticulosAscendenteCU(IRepositorioArticulos repositorioArticulos)
        {
            this._repositorioArticulos = repositorioArticulos;
        }
        public IEnumerable<ArticuloDTO> ObtenerArticulosAscendente()
        {
            return this._repositorioArticulos.FindAll()
                .OrderBy(articulo => articulo.Nombre)
                .Select(articulo => ArticuloDTOMapper.ToDto(articulo));
        }
    }
}

