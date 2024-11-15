using System;
using AppLogic.InterfacesCU.Clientes;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Clientes
{
    public class FiltrarPorMontoCU : IFiltrarPorMonto
    {
        private IRepositorioPedidos _repositorioPedidos;
        private IRepositorioClientes _repositorioClientes;

        public FiltrarPorMontoCU(IRepositorioClientes repositorioClientes, IRepositorioPedidos repositorioPedidos)
        {
            this._repositorioClientes = repositorioClientes;
            this._repositorioPedidos = repositorioPedidos;
        }

        public IEnumerable<Cliente> FiltrarPorMonto(double monto)
        {
            IEnumerable<Pedido> pedidos = _repositorioPedidos.GetPedidosPorMonto(monto);
            return this._repositorioClientes.GetClientesPorPedido(pedidos);
        }


    }
}

