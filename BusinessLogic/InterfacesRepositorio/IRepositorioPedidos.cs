using System;
using BussinessLogic.Entidades;

namespace BussinessLogic.InterfacesRepositorio
{
    public interface IRepositorioPedidos : IRepositorio<Pedido>
    {
        public IEnumerable<Pedido> GetPedidosPorMonto(double monto);

        public IEnumerable<Pedido> GetPedidosPorFecha(DateTime date);
    }
}


