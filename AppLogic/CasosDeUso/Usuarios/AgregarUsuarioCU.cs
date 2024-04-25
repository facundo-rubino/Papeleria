using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;
using AppLogic.Mappers;
using AppLogic.InterfacesCU.Usuarios;

namespace AppLogic.CasosDeUso.Usuarios
{
    public class AgregarUsuarioCU : IAgregarUsuario
    {
        private IRepositorioUsuarios _repositorioUsuarios;
        public AgregarUsuarioCU(IRepositorioUsuarios _repositorioUsuarios)
        {
            this._repositorioUsuarios = _repositorioUsuarios;
        }

        public void AgregarUsuario(UsuarioDTO aAgregar)
        {
            Usuario usuario = UsuarioDtoMapper.FromDto(aAgregar);
            this._repositorioUsuarios.Add(usuario);

        }
    }
}

