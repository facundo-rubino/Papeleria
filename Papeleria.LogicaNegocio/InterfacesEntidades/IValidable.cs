using System;
namespace Papeleria.LogicaNegocio.InterfacesEntidades
{
    public interface IValidable<T> where T : class
    {
        void EsValido();
    }
}

