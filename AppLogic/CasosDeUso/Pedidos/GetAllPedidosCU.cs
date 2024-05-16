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
    public class GetAllPedidosCU : IGetAllPedidos
    {
        private IRepositorioPedidos _repositorioPedidos;
        public GetAllPedidosCU(IRepositorioPedidos repositorioPedidos)
        {
            this._repositorioPedidos = repositorioPedidos;
        }
        public IEnumerable<PedidoDTO> GetAllPedidos()
        {
            return this._repositorioPedidos.FindAll().Select(pedido => PedidoDTOMapper.ToPedidoDTO(pedido));
        }
    }
}
