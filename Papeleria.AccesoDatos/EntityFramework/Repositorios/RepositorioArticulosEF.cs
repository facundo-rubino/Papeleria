using System;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioArticulosEF : IRepositorioArticulos
    {
        private PapeleriaContext context;
        public RepositorioArticulosEF()
        {
            context = new PapeleriaContext();
        }

        public bool Add(Articulo aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Articulo> FindAll()
        {
            return context.Articulos;
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

