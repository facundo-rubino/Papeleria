using AppLogic.DTOs;
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
    public class LineaDTOMapper
    {
        public static LineaDTO ToDto(Linea Linea)
        {
            return new LineaDTO(Linea);
        }
        public static Linea FromDto(LineaDTO dto)
        {
            if (dto == null) throw new LineaNoValidaException("El Linea no puede ser nulo");

            return new Linea(dto.Id, dto.Articulo, dto.Precio, dto.Cantidad);
        }
    }
}
