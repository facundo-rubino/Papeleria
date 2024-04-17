using System;
namespace BussinessLogic.InterfacesEntidades
{
    public interface IValidable<T> where T : class
    {
        void EsValido();
    }
}

