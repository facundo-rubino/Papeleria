using System;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Usuarios
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
            return UsuarioDtoMapper.ToDto(this._repositorioUsuarios.FindByEmail(email));
        }
    }
}

