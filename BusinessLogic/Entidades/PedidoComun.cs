using System;
namespace BussinessLogic.Entidades
{
    public class PedidoComun : Pedido
    {
        public int Recargo { get; private set; }
        public int Fecha { get; private set; }

        public PedidoComun()
        {
        }
    }
}

