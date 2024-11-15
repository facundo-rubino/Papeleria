using AppLogic.InterfacesCU.Pedidos;
using BussinessLogic.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.CasosDeUso.Pedidos
{
    public class UpdateEstadoPedidoCU : IActualizarEstado
    {
        private IRepositorioPedidos _repositorioPedidos;
        public UpdateEstadoPedidoCU(IRepositorioPedidos repositorioPedidos)
        {
            this._repositorioPedidos = repositorioPedidos;
        }
        public void UpdateEstadoPedido(int id, bool estado)
        {
            this._repositorioPedidos.UpdateEstadoPedido(id, estado);
        }
    }
}
