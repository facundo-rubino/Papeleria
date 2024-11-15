using System;
using AppLogic.HashPass;
using AppLogic.DTOs;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;
using BusinessLogic.Entidades;

namespace AppLogic.Mappers
{
    public class UsuarioDTOMapper
    {
        public static UsuarioDTO ToDto(Usuario usuario)
        {
            return new UsuarioDTO(usuario);
        }

        public static Usuario FromDto(UsuarioDTO dto)
        {
            if (dto == null) throw new UsuarioNoValidoException("El usuario no puede ser nulo");

            Rol rol = RolDTOMapper.FromDto(dto.Rol);
            Usuario usuario = new Usuario(dto.Nombre, dto.Apellido, dto.Email, dto.Pass, rol);
            usuario.Id = dto.Id;
            usuario.HashedPass = PasswordHasher.HashPassword(dto.Pass);
            return usuario;
        }
    }
}

