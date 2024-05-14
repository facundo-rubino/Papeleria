using System;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace BusinessLogic.InterfacesRepositorio
{
    public interface IRepositorioClientes : IRepositorio<Cliente>
    {
        public IEnumerable<Cliente> FiltroNombreCompleto(string txt);
    }
}

