using System;
using BusinessLogic.Excepciones;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;
using BussinessLogic.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioPedidosEF : IRepositorioPedidos
    {
        private PapeleriaContext _context;
        public RepositorioPedidosEF()
        {
            this._context = new PapeleriaContext();
        }

        public void Add(Pedido aAgregar)
        {
            try
            {
                aAgregar.EsValido(new RepositorioSettingsEF());
                this._context.Set<Pedido>().Add(aAgregar);
                this._context.Entry(aAgregar.Cliente).State = EntityState.Unchanged;
                _context.Pedidos.Add(aAgregar);
                _context.SaveChanges();
            }
            catch (PedidoNoValidoException exception)
            {
                throw exception;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Pedido> FindAll()
        {
            return _context.Pedidos;
        }

        public Pedido FindByID(int id)
        {
            return this._context.Pedidos.Where(user => user.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pedido aModificar)
        {
            throw new NotImplementedException();
        }
    }
}

