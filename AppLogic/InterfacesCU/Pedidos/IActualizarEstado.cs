using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.InterfacesCU.Pedidos
{
    public interface IActualizarEstado
    {
        public void UpdateEstadoPedido(int id, bool estado);
    }
}
