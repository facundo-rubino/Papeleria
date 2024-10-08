﻿using System;
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

                // aAgregar.AddHashedPassword(PasswordHasher.HashPassword(aAgregar.Pass));
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
            throw new NotImplementedException();
        }

        public Usuario FindByID(int id)
        {
            throw new NotImplementedException();
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

