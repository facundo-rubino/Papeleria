using System;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioPedidosEF : IRepositorioPedidos
    {
        private PapeleriaContext _context;
        public RepositorioPedidosEF()
        {
            this._context = new PapeleriaContext();
        }

        public bool Add(Pedido aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> FindAll()
        {
            throw new NotImplementedException();
        }

        public Pedido FindByID(int id)
        {
            return this._context.Pedidos.Where(user => user.Id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pedido aModificar)
        {
            throw new NotImplementedException();
        }
    }
}

