using System;
using BusinessLogic.Excepciones;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;
using BussinessLogic.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioPedidosEF : IRepositorioPedidos
    {
        private PapeleriaContext _context;
        private IRepositorioClientes _repositorioClientes;
        public RepositorioPedidosEF(IRepositorioClientes repositorioClientes)
        {
            this._context = new PapeleriaContext();
            this._repositorioClientes = repositorioClientes;
        }

        public void Add(Pedido aAgregar)
        {
            try
            {
                IRepositorioSettings settings = new RepositorioSettingsEF();
                if (!aAgregar.EsPedidoExpress)
                {
                    aAgregar.Cliente = this._repositorioClientes.FindByID(aAgregar.ClienteId);
                }
                aAgregar.EsValido(settings);
                aAgregar.CalcularCostosExtra(settings);
                aAgregar.Cliente = null;
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

        public IEnumerable<Pedido> GetPedidosPorMonto(double monto)
        {
            return _context.Pedidos.Where(pedido => pedido.MontoTotal >= monto);
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

