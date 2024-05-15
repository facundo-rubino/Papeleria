using System;
using AppLogic.DTOs;
using BussinessLogic.Entidades;

namespace AppLogic.Mappers
{
    public class PedidoDTOMapper
    {
        public static PedidoExpress ToPedidoExpress(PedidoDTO pedidoExpressDTO)
        {
            PedidoExpress retorno = new PedidoExpress
            {
                Recargo = pedidoExpressDTO.Recargo,
                FechaPrometida = pedidoExpressDTO.FechaPrometida,
                Fecha = pedidoExpressDTO.Fecha,
                ClienteId = pedidoExpressDTO.ClienteId,
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
                Fecha = pedidoComunDTO.Fecha,
                ClienteId = pedidoComunDTO.ClienteId,

            };
            if (pedidoComunDTO.Lineas != null)
            {
                retorno.Lineas = pedidoComunDTO.Lineas.Select(linea => LineaDTOMapper.FromDto(linea)).ToList();

            }
            return retorno;
        }
    }
}

