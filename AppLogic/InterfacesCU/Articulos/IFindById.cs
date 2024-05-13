using System;
using BussinessLogic.Entidades;

namespace AppLogic.InterfacesCU.Articulos
{
    public interface IFindById
    {
        public Articulo FindById(int id);
    }
}

