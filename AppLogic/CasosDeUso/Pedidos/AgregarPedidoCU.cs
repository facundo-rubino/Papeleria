using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Pedidos;
using AppLogic.Mappers;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Pedidos
{
    public class AgregarPedidoCU : IAgregarPedido
    {
        private IRepositorioPedidos _repositorioPedidos;
        public AgregarPedidoCU(IRepositorioPedidos repositorioPedidos)
        {
            this._repositorioPedidos = repositorioPedidos;
        }

        public void AgregarPedido(PedidoDTO aAgregar)
        {
            Pedido pedido = PedidoDTOMapper.FromDto(aAgregar);
            this._repositorioPedidos.Add(pedido);
        }
    }
}

