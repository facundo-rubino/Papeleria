using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Pedidos
{
    public interface IAgregarPedido
    {
        public void AgregarPedido(PedidoDTO pedido);
    }
}

