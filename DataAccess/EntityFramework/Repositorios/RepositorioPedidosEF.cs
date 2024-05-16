using System;
using BusinessLogic.Excepciones;
using BussinessLogic.Entidades;
using BussinessLogic.Excepciones;
using BussinessLogic.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public IEnumerable<Pedido> GetPedidosConCliente()
        {
            return _context.Pedidos.Include(p => p.Cliente).ToList();
        }

        public IEnumerable<Pedido> GetPedidosConCliente(DateTime date)
        {
            return _context.Pedidos.Include(p => p.Cliente)
                                 .Where(p => p.FechaPrometida.Date == date.Date)
                                 .ToList();
        }

        public IEnumerable<Pedido> GetPedidosAnuladosConCliente()
        {
            return _context.Pedidos.Include(p => p.Cliente)
                               .Where(p => p.PedidoAnulado == true)
                               .OrderByDescending(p => p.FechaPrometida)
                               .ToList();
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

        public void UpdateEstadoPedido(int id, bool estado)
        {
            Pedido pedido = this.FindByID(id);
            if (pedido != null)
            {
                pedido.PedidoAnulado = estado;
                this._context.Pedidos.Update(pedido);
                this._context.SaveChanges();
            }
        }


    }
}

