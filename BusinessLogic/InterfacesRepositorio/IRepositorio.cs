using System;
using BussinessLogic.Entidades;

namespace BussinessLogic.InterfacesRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindByID(int id);
        bool Add(T aAgregar);
        bool Remove(int id);
        bool Update(T aModificar);
    }
}

