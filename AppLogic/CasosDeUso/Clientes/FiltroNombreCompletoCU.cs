using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Clientes;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.Entidades;
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

        public IEnumerable<Cliente> FiltrarPorNombreCompleto(string txt)
        {
            return this._repositorioClientes.FiltroNombreCompleto(txt);
        }
    }
}

