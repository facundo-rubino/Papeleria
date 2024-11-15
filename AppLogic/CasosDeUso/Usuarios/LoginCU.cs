using System;
using AppLogic.DTOs;
using AppLogic.HashPass;
using AppLogic.InterfacesCU.Usuarios;
using AppLogic.Mappers;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;

namespace AppLogic.CasosDeUso.Usuarios
{
    public class LoginCU : ILogin
    {
        private IFindByEmail _userByEmail;
        private IUpdateHashPass _updateHashCU;

        public LoginCU(IFindByEmail user, IUpdateHashPass updateHashCU)
        {
            this._userByEmail = user;
            this._updateHashCU = updateHashCU;
        }

        public bool LoginIsValid(string email, string pass)
        {
            UsuarioDTO userDTO = this._userByEmail.GetUserByEmail(email);
            if (userDTO != null)
            {
                if (userDTO.HashedPass == null && userDTO.Id != 0)
                {
                    string hash = PasswordHasher.HashPassword(userDTO.Pass);
                    this._updateHashCU.UpdateHashPass(userDTO, hash);
                    return true;
                }
                else
                {
                    return PasswordHasher.VerifyPassword(userDTO.HashedPass, pass);
                }
            }
            else
            {
                throw new UsuarioNoValidoException("Usuario y/o contraseña incorrectos");
            }
        }

    }
}

