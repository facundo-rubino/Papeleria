using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Usuarios
{
    public interface IUpdateHashPass
    {
        public void UpdateHashPass(UsuarioDTO dto, string hash);

    }
}

