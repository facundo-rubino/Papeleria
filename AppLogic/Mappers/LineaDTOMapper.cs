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
        public static LineaDTO ToDto(Linea linea)
        {
            return new LineaDTO
            {
                Articulo = linea.Articulo,
                Cantidad = linea.Cantidad,
                Precio = linea.Precio
            };
        }
        public static Linea FromDto(LineaDTO dto)
        {
            if (dto == null) throw new LineaNoValidaException("El Linea no puede ser nula");

            return new Linea
            {
                Articulo = dto.Articulo,
                Cantidad = dto.Cantidad,
                Precio = dto.Precio,
            };
        }
    }
}
