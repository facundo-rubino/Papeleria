using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Usuarios;
using AppLogic.Mappers;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Usuarios
{
    public class FindByEmailCU : IFindByEmail
    {
        private IRepositorioUsuarios _repositorioUsuarios;

        public FindByEmailCU(IRepositorioUsuarios _repositorioUsuarios)
        {
            this._repositorioUsuarios = _repositorioUsuarios;
        }

        public UsuarioDTO GetUserByEmail(string email)
        {
            return UsuarioDTOMapper.ToDto(this._repositorioUsuarios.FindByEmail(email));
        }
    }
}

