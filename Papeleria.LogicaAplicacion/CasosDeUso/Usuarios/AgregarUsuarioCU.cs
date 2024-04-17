using System;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.Mappers;

namespace Papeleria.LogicaAplicacion.CasosDeUso
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

