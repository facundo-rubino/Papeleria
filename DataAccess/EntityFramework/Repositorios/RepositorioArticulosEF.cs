using System;
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
            this._context = new PapeleriaContext();
        }

        public void Add(Articulo aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                _context.Articulos.Add(aAgregar);
                _context.SaveChanges();
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


        public IEnumerable<Articulo> FindAll()
        {
            return _context.Articulos;
        }

        public Articulo FindByID(int id)
        {
            return this._context.Articulos.Where(user => user.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            Articulo aBorrar = this.FindByID(id);
            if (aBorrar != null)
            {
                this._context.Articulos.Remove(aBorrar);

            }
        }

        public void Update(Articulo aModificar)
        {
            throw new NotImplementedException();
        }
    }
}

