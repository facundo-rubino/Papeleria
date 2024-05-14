using BusinessLogic.InterfacesRepositorio;
using System;
namespace BussinessLogic.Entidades
{
    public class PedidoExpress : Pedido
    {
        public PedidoExpress()
        {
        }

        protected override void CalcularIVA(IRepositorioSettings repositorioSettings)
        {

        }
    }

}

