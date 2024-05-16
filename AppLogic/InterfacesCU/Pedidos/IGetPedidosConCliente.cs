using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.InterfacesCU.Pedidos
{
    public interface IGetPedidosConCliente
    {
        public IEnumerable<PedidoDTO> GetPedidosConCliente();
        public IEnumerable<PedidoDTO> GetPedidosConCliente(DateTime date);
        public IEnumerable<PedidoDTO> GetPedidosAnuladosCliente();
    }
}
