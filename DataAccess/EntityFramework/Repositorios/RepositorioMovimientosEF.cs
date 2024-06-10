using System;
using BusinessLogic.Entidades;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.InterfacesRepositorio;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioMovimientosEF : IRepositorioMovimientos
    {
        private PapeleriaContext _context;

        public RepositorioMovimientosEF()
        {
            this._context = new PapeleriaContext();
        }

        public void Add(Movimiento aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movimiento> FindAll()
        {
            return _context.Movimientos;
        }

        public Movimiento FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Movimiento aModificar)
        {
            throw new NotImplementedException();
        }
    }
}

