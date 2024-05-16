using System;
using BussinessLogic.Entidades;

namespace BussinessLogic.InterfacesRepositorio
{
    public interface IRepositorioPedidos : IRepositorio<Pedido>
    {
        public IEnumerable<Pedido> GetPedidosPorMonto(double monto);

        public IEnumerable<Pedido> GetPedidosConCliente();

        public IEnumerable<Pedido> GetPedidosConCliente(DateTime date);

        public IEnumerable<Pedido> GetPedidosAnuladosConCliente();

        public void UpdateEstadoPedido(int id, bool estado);


    }
}


