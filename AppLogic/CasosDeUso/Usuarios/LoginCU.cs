using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Usuarios;
using AppLogic.Mappers;
using BussinessLogic.Entidades;

namespace AppLogic.CasosDeUso.Usuarios
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

