using System;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaNegocio.Entidades;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Usuarios
{
    public interface IFindByEmail
    {
        public UsuarioDTO GetUserByEmail(string email);
    }
}

