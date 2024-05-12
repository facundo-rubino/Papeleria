using System;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;
using BussinessLogic.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioUsuariosEF : IRepositorioUsuarios
    {
        private PapeleriaContext _context;

        public RepositorioUsuariosEF()
        {
            this._context = new PapeleriaContext();
        }

        public void Add(Usuario aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                _context.Usuarios.Add(aAgregar);
                _context.SaveChanges();
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

        public Usuario FindByID(int id)
        {
            return this._context.Usuarios.Where(user => user.Id == id).FirstOrDefault();
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.Where(usuario => usuario.Email == email).FirstOrDefault();
        }

        public void Remove(int id)
        {
            Usuario aBorrar = this.FindByID(id);
            if (aBorrar != null)
            {
                this._context.Usuarios.Remove(aBorrar);
                this._context.SaveChanges();
            }
        }

        public void Update(Usuario aActualizar)
        {
            try
            {
                if (aActualizar == null || aActualizar.Id == 0)
                {
                    throw new UsuarioNoValidoException("Falta Id.");
                }
                aActualizar.EsValido();
                this._context.Usuarios.Update(aActualizar);

            }
            catch (UsuarioNoValidoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

