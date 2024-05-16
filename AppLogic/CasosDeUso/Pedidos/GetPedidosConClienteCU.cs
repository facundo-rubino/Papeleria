using AppLogic.DTOs;
using AppLogic.InterfacesCU.Pedidos;
using AppLogic.Mappers;
using BussinessLogic.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.CasosDeUso.Pedidos
{
    public class GetPedidosConClienteCU : IGetPedidosConCliente
    {
        private IRepositorioPedidos _repositorioPedidos;
        public GetPedidosConClienteCU(IRepositorioPedidos repositorioPedidos)
        {
            this._repositorioPedidos = repositorioPedidos;
        }
        public IEnumerable<PedidoDTO> GetPedidosConCliente()
        {
            return this._repositorioPedidos.GetPedidosConCliente().Select(pedido => PedidoDTOMapper.ToPedidoDTO(pedido));
        }

        public IEnumerable<PedidoDTO> GetPedidosConCliente(DateTime date)
        {
            return this._repositorioPedidos.GetPedidosConCliente(date).Select(pedido => PedidoDTOMapper.ToPedidoDTO(pedido));
        }

        public IEnumerable<PedidoDTO> GetPedidosAnuladosCliente()
        {
            return this._repositorioPedidos.GetPedidosAnuladosConCliente().Select(pedido => PedidoDTOMapper.ToPedidoDTO(pedido));
        }
    }
}
