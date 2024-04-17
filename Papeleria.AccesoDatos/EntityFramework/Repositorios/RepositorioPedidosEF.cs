using System;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPedidosEF : IRepositorioPedidos
    {
        private PapeleriaContext context;
        public RepositorioPedidosEF()
        {
            context = new PapeleriaContext();
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
            throw new NotImplementedException();
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

