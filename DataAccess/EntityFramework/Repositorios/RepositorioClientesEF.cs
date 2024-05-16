using System;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioClientesEF : IRepositorioClientes
    {
        private PapeleriaContext _context;
        private IRepositorioPedidos _repositorioPedidos;

        public RepositorioClientesEF(IRepositorioPedidos repositorioPedidos)
        {
            this._context = new PapeleriaContext();
            this._repositorioPedidos = repositorioPedidos;
        }

        public void Add(Cliente aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> FiltroNombreCompleto(string word)
        {
            return _context.Clientes
               .Where(cliente => cliente.Contacto.Nombre.ToLower().Contains(word.ToLower()) || cliente.Contacto.Apellido.ToLower().Contains(word.ToLower()));
        }

        public IEnumerable<Cliente> GetClientesPorMonto(double monto)
        {
            IEnumerable<Pedido> pedidos = this._repositorioPedidos.GetPedidosPorMonto(monto);
            return pedidos.Select(pedido => pedido.Cliente).Distinct();
        }

        public IEnumerable<Cliente> FindAll()
        {
            return _context.Clientes;
        }

        public Cliente FindByID(int id)
        {
            return this._context.Clientes.Where(user => user.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente aModificar)
        {
            throw new NotImplementedException();
        }
    }
}

