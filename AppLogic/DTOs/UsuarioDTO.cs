using System;
using BussinessLogic.Entidades;
namespace AppLogic.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string HashedPass { get; private set; }

        public UsuarioDTO() { }

        public UsuarioDTO(Usuario usuario)
        {
            if (usuario != null)
            {
                this.Nombre = usuario.NombreCompleto.Nombre;
                this.Apellido = usuario.NombreCompleto.Apellido;
                this.Id = usuario.Id;
                this.Pass = usuario.Pass;
                this.HashedPass = usuario.HashedPass;
            }

        }


    }
}

