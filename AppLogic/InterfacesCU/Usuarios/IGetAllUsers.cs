using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Usuarios
{
    public interface IGetAllUsers
    {
        public IEnumerable<UsuarioDTO> GetAllUsers();
    }
}

