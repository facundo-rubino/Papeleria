using System;
using AppLogic.DTOs;
using BussinessLogic.Entidades;

namespace AppLogic.InterfacesCU.Pedidos
{
    public interface IAgregarPedido
    {
        public void AgregarPedidoComun(PedidoDTO aAgregar);
        public void AgregarPedidoExpress(PedidoDTO aAgregar);

    }
}

