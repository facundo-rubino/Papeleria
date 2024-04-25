using System;
using AppLogic.DTOs;
using AppLogic.HashPass;
using AppLogic.InterfacesCU.Usuarios;
using AppLogic.Mappers;
using BussinessLogic.Entidades;

namespace AppLogic.CasosDeUso.Usuarios
{
    public class LoginCU : ILogin
    {
        private IFindByEmail _userByEmail;

        public LoginCU(IFindByEmail user)
        {
            this._userByEmail = user;
        }

        public bool LoginIsValid(string email, string pass)
        {
            UsuarioDTO userDTO = this._userByEmail.GetUserByEmail(email);
            var verifyPass = PasswordHasher.VerifyPassword(userDTO.HashedPass, pass);
            return userDTO != null && verifyPass;
        }

    }
}

