using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Pedidos
{
    public interface IObtenerAnuladosDescendente
    {
        public IEnumerable<PedidoDTO> ObtenerAnuladosDescendente();
    }
}

