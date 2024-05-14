using BusinessLogic.InterfacesRepositorio;
using System;
namespace BussinessLogic.Entidades
{
    public class PedidoComun : Pedido
    {
        public PedidoComun()
        {
        }

        protected override void CalcularIVA(IRepositorioSettings repositorioSettings)
        {

        }

    }
}

