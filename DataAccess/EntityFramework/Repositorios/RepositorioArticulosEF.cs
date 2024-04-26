﻿using System;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;
using BussinessLogic.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioArticulosEF : IRepositorioArticulos
    {
        private PapeleriaContext _context;
        public RepositorioArticulosEF()
        {
            _context = new PapeleriaContext();
        }

        public bool Add(Articulo aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                _context.Articulos.Add(aAgregar);
                _context.SaveChanges();
                return true;
            }
            catch (ArticuloNoValidoException exception)
            {
                throw exception;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExisteArticulo(Articulo aBuscar)
        {
           var existeArticulo = this._context.Articulos.Where(a => a.Nombre == aBuscar.Nombre || a.Codigo == aBuscar.Codigo).FirstOrDefault();
           if (existeArticulo != null) return true;
           else return false;
        }

        public IEnumerable<Articulo> FindAll()
        {
            return _context.Articulos;
        }

        public Articulo FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Articulo aModificar)
        {
            throw new NotImplementedException();
        }
    }
}

