using System;
using AppLogic.DTOs;
using BussinessLogic.Entidades;

namespace AppLogic.InterfacesCU.Usuarios
{
    public interface IFindByEmail
    {
        public UsuarioDTO GetUserByEmail(string email);
    }
}

