﻿using System;
using AppLogic.HashPass;
using AppLogic.DTOs;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;

namespace AppLogic.Mappers
{
    public class UsuarioDtoMapper
    {
        public static UsuarioDTO ToDto(Usuario usuario)
        {
            return new UsuarioDTO(usuario);
        }

        public static Usuario FromDto(UsuarioDTO dto)
        {
            if (dto == null) throw new UsuarioNoValidoException("El usuario no puede ser nulo");

            var hashedPass = PasswordHasher.HashPassword(dto.Pass);
            return new Usuario(dto.Nombre, dto.Apellido, dto.Email, dto.Pass, hashedPass);
        }
    }
}

