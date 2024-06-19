using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Articulos;
using AppLogic.Mappers;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Articulos
{
    public class FindAllArticulosPaginadoCU : IFindAllArticulosPaginado
    {
        private IRepositorioArticulos _repositorioArticulos;
        private IRepositorioSettings _repositorioSettings;
        public FindAllArticulosPaginadoCU(
            IRepositorioArticulos repositorioArticulos,
            IRepositorioSettings repositorioSettings)
        {
            this._repositorioArticulos = repositorioArticulos;
            this._repositorioSettings = repositorioSettings;
        }

        public IEnumerable<ArticuloDTO> FindAllPaginado(int pag)
        {
            int size = int.Parse(this._repositorioSettings.GetValueByName("PagSize") + "");
            return this._repositorioArticulos.FindAllPaginado(pag, size).Select(articulo => ArticuloDTOMapper.ToDto(articulo));
        }
    }
}

