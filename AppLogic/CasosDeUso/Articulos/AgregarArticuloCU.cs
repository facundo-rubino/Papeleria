using AppLogic.DTOs;
using AppLogic.InterfacesCU.Articulos;
using AppLogic.Mappers;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.CasosDeUso.Articulos
{
    public class AgregarArticuloCU : IAgregarArticulo
    {
        private IRepositorioArticulos _repositorioArticulos;

            public AgregarArticuloCU(IRepositorioArticulos repositorioArticulos)
        {
            this._repositorioArticulos = repositorioArticulos;
        }

        public void AgregarArticulo(ArticuloDTO aAgregar)
        {
            Articulo articulo = ArticuloDTOMapper.FromDto(aAgregar);
            this._repositorioArticulos.Add(articulo);
        }
    }
}
