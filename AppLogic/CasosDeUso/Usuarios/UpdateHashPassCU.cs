using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Usuarios;
using AppLogic.Mappers;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;
using Microsoft.AspNetCore.Components.Forms;

namespace AppLogic.CasosDeUso.Usuarios
{

    public class UpdateHashPassCU : IUpdateHashPass
    {
        private IRepositorioUsuarios _repositorioUsuarios;

        public UpdateHashPassCU(IRepositorioUsuarios repositorioUsuarios)
        {
            this._repositorioUsuarios = repositorioUsuarios;
        }

        public void UpdateHashPass(UsuarioDTO dto, string hash)
        {
            Usuario usuario = UsuarioDTOMapper.FromDto(dto);
            this._repositorioUsuarios.UpdateHashedPass(usuario, hash);
        }

    }

}

