using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Usuarios;
using AppLogic.Mappers;
using BussinessLogic.InterfacesRepositorio;

namespace AppLogic.CasosDeUso.Usuarios
{
    public class GetAllUsersCU : IGetAllUsers
    {

        private IRepositorioUsuarios _repositorioUsuarios;
        public GetAllUsersCU(IRepositorioUsuarios repositorioUsuarios)
        {
            this._repositorioUsuarios = repositorioUsuarios;
        }

        public IEnumerable<UsuarioDTO> GetAllUsers()
        {
            return this._repositorioUsuarios.FindAll().Select(Usuario => UsuarioDTOMapper.ToDto(Usuario));
        }

    }
}

