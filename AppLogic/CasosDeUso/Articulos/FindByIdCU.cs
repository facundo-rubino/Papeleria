using System;
using AppLogic.InterfacesCU.Articulos;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Articulos
{
    public class FindByIdCU : IFindById
    {
        private IRepositorioArticulos _repositorioArticulos;

        public FindByIdCU(IRepositorioArticulos repositorioArticulos)
        {
            this._repositorioArticulos = repositorioArticulos;
        }

        public Articulo FindById(int id)
        {
            return this._repositorioArticulos.FindByID(id);
        }
    }
}

