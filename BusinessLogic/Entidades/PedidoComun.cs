using System;
namespace BussinessLogic.Entidades
{
    public class PedidoComun : Pedido
    {
        public int Recargo { get; set; }
        public int Fecha { get; set; }

        public PedidoComun()
        {
        }
    }
}

