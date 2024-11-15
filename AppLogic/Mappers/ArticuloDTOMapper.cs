using AppLogic.DTOs;
using AppLogic.HashPass;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Mappers
{
    public class ArticuloDTOMapper
    {
        public static ArticuloDTO ToDto(Articulo Articulo)
        {
            return new ArticuloDTO(Articulo);
        }

        public static Articulo FromDto(ArticuloDTO dto)
        {
            if (dto == null) throw new ArticuloNoValidoException("El Articulo no puede ser nulo");

            return new Articulo(dto.Nombre, dto.Descripcion, dto.Codigo, dto.PrecioUnitario, dto.Stock);
        }
    }
}
