using System;
using AppLogic.DTOs;
using AppLogic.HashPass;
using BusinessLogic.Excepciones;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;

namespace AppLogic.Mappers
{
    public class PedidoDTOMapper
    {
        public static PedidoDTO ToDto(Pedido pedido)
        {
            if (pedido == null) return null;
            PedidoDTO dto = new PedidoDTO
            {
                Recargo = pedido.Recargo,
                FechaPrometida = pedido.FechaPrometida,
                Fecha = pedido.Fecha,
                Cliente = pedido.Cliente
            };
            if (pedido.Lineas != null)
            {
                dto.Lineas = pedido.Lineas.Select(linea => LineaDTOMapper.ToDto(linea)).ToList();
            }
            return dto;

        }



        public static Pedido FromDto(PedidoDTO PedidoDTO)
        {
            Pedido retorno = new Pedido
            {
                Recargo = PedidoDTO.Recargo,
                FechaPrometida = PedidoDTO.FechaPrometida,
                Fecha = PedidoDTO.Fecha,
                Cliente = PedidoDTO.Cliente

            };
            if (PedidoDTO.Lineas != null)
            {
                retorno.Lineas = PedidoDTO.Lineas.Select(linea => LineaDTOMapper.FromDto(linea)).ToList();

            }
            return retorno;

        }



    }
}

