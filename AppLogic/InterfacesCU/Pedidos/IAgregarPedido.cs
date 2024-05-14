using System;
using AppLogic.DTOs;
using BussinessLogic.Entidades;

namespace AppLogic.InterfacesCU.Pedidos
{
    public interface IAgregarPedido
    {
        public void AgregarPedidoComun(PedidoComunDTO aAgregar);
        public void AgregarPedidoExpress(PedidoExpressDTO aAgregar);

    }
}

