using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Pedidos;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Pedidos
{
    public class ObtenerAnuladosCU : IObtenerAnuladosDescendente
    {
        private IRepositorioPedidos _repositorioPedidos;
        public ObtenerAnuladosCU(IRepositorioPedidos repositorioPedidos)
        {
            this._repositorioPedidos = repositorioPedidos;
        }

        public IEnumerable<PedidoDTO> ObtenerAnuladosDescendente()
        {
            throw new NotImplementedException();
        }

    }

}