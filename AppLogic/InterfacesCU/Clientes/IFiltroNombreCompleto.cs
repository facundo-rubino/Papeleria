using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Clientes
{
    public interface IFiltroNombreCompleto
    {
        public IEnumerable<ClienteDTO> FiltrarPorNombreCompleto(string txt);
    }
}

