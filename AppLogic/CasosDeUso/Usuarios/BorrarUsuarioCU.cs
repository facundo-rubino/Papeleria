using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Usuarios;
using AppLogic.Mappers;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Usuarios
{
    public class BorrarUsuarioCU : IBorrarUsuario
    {
        private IRepositorioUsuarios _repositorioUsuarios;
        public BorrarUsuarioCU(IRepositorioUsuarios _repositorioUsuarios)
        {
            this._repositorioUsuarios = _repositorioUsuarios;
        }

        public void BorrarUsuario(int Id)
        {
            // Usuario usuario = UsuarioDTOMapper.FromDto(aBorrar);
            this._repositorioUsuarios.Remove(Id);

        }
    }
}

