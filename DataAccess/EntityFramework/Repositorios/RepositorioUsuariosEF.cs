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
            return _context.Usuarios.Where(usuario => usuario.Email == email).Include(u => u.Rol).FirstOrDefault();
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
                _context.SaveChanges();

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

        public void UpdateHashedPass(Usuario usuario, string newHashedPass)
        {
            try
            {
                // Recuperar la entidad existente del contexto usando AsNoTracking para evitar el seguimiento
                var existingUsuario = _context.Usuarios.AsNoTracking().Include(u => u.Rol).SingleOrDefault(u => u.Id == usuario.Id);

                if (existingUsuario == null)
                {
                    throw new UsuarioNoValidoException("Usuario no encontrado.");
                }

                // Desvincular cualquier instancia rastreada de la entidad con el mismo valor de clave
                var trackedEntity = _context.Usuarios.Local.FirstOrDefault(u => u.Id == usuario.Id);
                if (trackedEntity != null)
                {
                    // Cambiar el estado de la entidad rastreada a Detached
                    _context.Entry(trackedEntity).State = EntityState.Detached;
                }

                // Crear una nueva instancia y establecer la clave y la nueva contraseña hasheada
                var updatedUsuario = new Usuario
                {
                    Id = usuario.Id,
                    HashedPass = newHashedPass,
                };

                // Adjuntar la entidad actualizada y marcar solo la propiedad HashedPass como modificada
                _context.Usuarios.Attach(updatedUsuario);
                _context.Entry(updatedUsuario).Property(u => u.HashedPass).IsModified = true;

                _context.SaveChanges();

                //gpt help: https://chatgpt.com/share/7cbe9607-fc3d-4b49-9c36-aecea63d04a7
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

