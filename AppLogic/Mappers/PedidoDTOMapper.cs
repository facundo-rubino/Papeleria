using System;
using AppLogic.CasosDeUso.Clientes;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Clientes;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.Entidades;

namespace AppLogic.Mappers
{
    public class PedidoDTOMapper
    {
        private IRepositorioClientes _repositorioClientes;

        public PedidoDTOMapper(IRepositorioClientes repositorioClientes)
        {
            this._repositorioClientes = repositorioClientes;
        }

        public static PedidoExpress ToPedidoExpress(PedidoDTO pedidoExpressDTO)
        {
            PedidoExpress retorno = new PedidoExpress
            {
                Recargo = pedidoExpressDTO.Recargo,
                FechaPrometida = pedidoExpressDTO.FechaPrometida,
                Fecha = DateTime.Today,
                ClienteId = pedidoExpressDTO.ClienteId,
                EsPedidoExpress = true
            };
            if (pedidoExpressDTO.Lineas != null)
            {
                retorno.Lineas = pedidoExpressDTO.Lineas.Select(linea => LineaDTOMapper.FromDto(linea)).ToList();

            }
            return retorno;
        }

        public static PedidoComun ToPedidoComun(PedidoDTO pedidoComunDTO)
        {
            PedidoComun retorno = new PedidoComun
            {
                Recargo = pedidoComunDTO.Recargo,
                FechaPrometida = pedidoComunDTO.FechaPrometida,
                Fecha = DateTime.Today,
                ClienteId = pedidoComunDTO.ClienteId,
                EsPedidoExpress = false

            };
            if (pedidoComunDTO.Lineas != null)
            {
                retorno.Lineas = pedidoComunDTO.Lineas.Select(linea => LineaDTOMapper.FromDto(linea)).ToList();

            }
            return retorno;
        }




    }
}

