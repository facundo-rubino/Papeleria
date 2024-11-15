using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Usuarios;
using AppLogic.Mappers;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Usuarios
{
    public class UpdateUserCU : IUpdateUser
    {
        private IRepositorioUsuarios _repositorioUsuarios;

        public UpdateUserCU(IRepositorioUsuarios repositorioUsuarios)
        {
            this._repositorioUsuarios = repositorioUsuarios;
        }

        public void UpdateUser(UsuarioDTO aEditar)
        {
            Usuario usuario = UsuarioDTOMapper.FromDto(aEditar);
            this._repositorioUsuarios.Update(usuario);
        }

    }
}

