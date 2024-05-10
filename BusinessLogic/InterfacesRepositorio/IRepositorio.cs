using System;
using BussinessLogic.Entidades;

namespace BussinessLogic.InterfacesRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindByID(int id);
        void Add(T aAgregar);
        void Remove(int id);
        void Update(T aModificar);
    }
}

