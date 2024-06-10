using System;
using AppLogic.DTOs;
using BusinessLogic.Entidades;
using BusinessLogic.Excepciones;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;

namespace AppLogic.Mappers
{
    public class MovimientoDTOMapper
    {
        public static MovimientoDTO ToDto(Movimiento movimiento)
        {
            return new MovimientoDTO(movimiento);
        }

        public static Movimiento FromDto(MovimientoDTO dto)
        {
            if (dto == null) throw new MovimientoNoValidoException("El Movimiento no puede ser nulo");
            Movimiento mov = new Movimiento(dto.FechaHora, dto.ArticuloId, dto.UsuarioId, dto.TipoId, dto.Cant);
            return mov;
        }
    }
}

