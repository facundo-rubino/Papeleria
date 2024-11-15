using System;
using Microsoft.EntityFrameworkCore;
using BussinessLogic.Entidades;

namespace BussinessLogic.InterfacesRepositorio
{
    public interface IRepositorioUsuarios : IRepositorio<Usuario>
    {
        public Usuario FindByEmail(string email);
        public void UpdateHashedPass(Usuario usuario, string newHashedPass);
    }
}

