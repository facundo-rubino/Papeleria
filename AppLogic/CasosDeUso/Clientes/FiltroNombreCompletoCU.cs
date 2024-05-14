using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Clientes;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Clientes
{
    public class FiltroNombreCompletoCU : IFiltroNombreCompleto
    {

        private IRepositorioClientes _repositorioClientes;
        public FiltroNombreCompletoCU(IRepositorioClientes repositorioClientes)
        {
            this._repositorioClientes = repositorioClientes;
        }

        public IEnumerable<ClienteDTO> FiltrarPorNombreCompleto(string txt)
        {
            throw new NotImplementedException();
        }
    }
}

