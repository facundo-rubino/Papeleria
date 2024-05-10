using System;
namespace BussinessLogic.Entidades
{
    public class PedidoExpress : Pedido
    {
        public int Recargo { get; private set; }
        public int Fecha { get; private set; }

        public PedidoExpress()
        {
        }

    }

}

