using System;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;
using BussinessLogic.InterfacesRepositorio;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioUsuariosEF : IRepositorioUsuarios
    {
        private PapeleriaContext _context;

        public RepositorioUsuariosEF()
        {
            this._context = new PapeleriaContext();
        }

        public bool Add(Usuario aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                _context.Usuarios.Add(aAgregar);
                _context.SaveChanges();
                return true;
            }
            catch (UsuarioNoValidoException exception)
            {
                throw exception;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return _context.Usuarios;
        }


        public IEnumerable<Usuario> GetArticuloByName(string aBuscar)
        {
            return _context.Usuarios;
                //.Where(u => u.NombreCompleto.Contains(aBuscar));
                //.Include(team => team.Players);
        }

        public Usuario FindByID(int id)
        {
            return this._context.Usuarios.Where(user => user.Id == id).FirstOrDefault();
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.Where(usuario => usuario.Email == email).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario aModificar)
        {
            throw new NotImplementedException();
        }


    }
}

