﻿using AppLogic.DTOs;
using BusinessLogic.Entidades;
using BusinessLogic.Excepciones;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Mappers
{
    public class TipoMovimientoDTOMapper
    {
        public static TipoMovimientoDTO ToDto(TipoMovimiento TipoMovimiento)
        {
            if (TipoMovimiento == null) return null;
            return new TipoMovimientoDTO(TipoMovimiento);
        }

        public static TipoMovimiento FromDto(TipoMovimientoDTO dto)
        {
            if (dto == null) throw new TipoMovimientoNoValidoException("El Tipo de movimiento no puede ser nulo");
            TipoMovimiento tipoMovimiento = new TipoMovimiento(dto.Nombre, dto.Signo);
            tipoMovimiento.Id = dto.Id;
            return tipoMovimiento;
        }
    }
}
