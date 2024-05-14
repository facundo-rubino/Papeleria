using System;
using AppLogic.DTOs;
using BussinessLogic.Entidades;

namespace AppLogic.Mappers
{
    public class PedidoDTOMapper
    {
        public static PedidoExpress ToPedidoExpress(PedidoExpressDTO pedidoExpressDTO)
        {
            PedidoExpress retorno = new PedidoExpress
            {
                Recargo = pedidoExpressDTO.Recargo,
                FechaPrometida = pedidoExpressDTO.FechaPrometida,
                Fecha = pedidoExpressDTO.Fecha,
                Cliente = pedidoExpressDTO.Cliente

            };
            if (pedidoExpressDTO.Lineas != null)
            {
                retorno.Lineas = pedidoExpressDTO.Lineas.Select(linea => LineaDTOMapper.FromDto(linea)).ToList();

            }
            return retorno;
        }

        public static PedidoComun ToPedidoComun(PedidoComunDTO pedidoComunDTO)
        {
            PedidoComun retorno = new PedidoComun
            {
                Recargo = pedidoComunDTO.Recargo,
                FechaPrometida = pedidoComunDTO.FechaPrometida,
                Fecha = pedidoComunDTO.Fecha,
                Cliente = pedidoComunDTO.Cliente

            };
            if (pedidoComunDTO.Lineas != null)
            {
                retorno.Lineas = pedidoComunDTO.Lineas.Select(linea => LineaDTOMapper.FromDto(linea)).ToList();

            }
            return retorno;
        }
    }
}

