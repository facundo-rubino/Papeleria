using System;
using BussinessLogic.Entidades;

namespace AppLogic.InterfacesCU.Clientes
{
    public interface IFiltrarPorMonto
    {
        public IEnumerable<Cliente> FiltrarPorMonto(double monto);
    }
}

