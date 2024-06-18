using AppLogic.DTOs;
using BusinessLogic.Entidades;
using BusinessLogic.Excepciones;
using BussinessLogic.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Mappers
{
    public class RolDTOMapper
    {
        public static RolDTO ToDto(Rol Rol)
        {
            return new RolDTO(Rol);
        }

        public static Rol FromDto(RolDTO dto)
        {
            if (dto == null) throw new RolNoValidoException("El Rol no puede ser nulo");
            Rol Rol = new Rol(dto.Nombre);
            Rol.Id = dto.Id;
            return Rol;
        }
    }
}
