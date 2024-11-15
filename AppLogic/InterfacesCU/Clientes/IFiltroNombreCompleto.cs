using System;
using AppLogic.DTOs;
using BussinessLogic.Entidades;

namespace AppLogic.InterfacesCU.Clientes
{
    public interface IFiltroNombreCompleto
    {
        public IEnumerable<Cliente> FiltrarPorNombreCompleto(string txt);
    }
}

