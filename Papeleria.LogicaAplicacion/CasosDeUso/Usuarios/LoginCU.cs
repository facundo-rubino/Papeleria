using System;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Usuarios
{
    public class LoginCU : ILogin
    {
        private FindByEmailCU _userByEmail;

        public LoginCU(FindByEmailCU user)
        {
            this._userByEmail = user;
        }

        public bool LoginIsValid(string email, string pass)
        {
            UsuarioDTO userDTO = this._userByEmail.GetUserByEmail(email);
            return userDTO != null && pass == userDTO.Pass;
        }


    }
}

