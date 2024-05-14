using System;
namespace BussinessLogic.Entidades
{
    public class PedidoExpress : Pedido
    {
        public int Recargo { get; set; }
        public int Fecha { get; set; }

        public PedidoExpress()
        {
        }

    }

}

