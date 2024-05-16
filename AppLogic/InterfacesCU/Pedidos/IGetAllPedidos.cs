using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.InterfacesCU.Pedidos
{
    public interface IGetAllPedidos
    {
        public IEnumerable<PedidoDTO> GetAllPedidos();
    }
}
