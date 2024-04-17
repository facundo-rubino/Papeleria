using System;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;

namespace Papeleria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioUsuarios : IRepositorio<Usuario>
    {
        public Usuario FindByEmail(string email);
    }
}

