using System;
using BussinessLogic.Entidades;

namespace BussinessLogic.InterfacesRepositorio
{
    public interface IRepositorioClientes : IRepositorio<Cliente>
    {
        public IEnumerable<Cliente> FiltroNombreCompleto(string txt);
        public IEnumerable<Cliente> GetClientesPorPedido(IEnumerable<Pedido> pedidos);

    }
}

