﻿using System;
using BussinessLogic.InterfacesRepositorio;
using BussinessLogic.Entidades;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioClientesEF : IRepositorioClientes
    {
        private PapeleriaContext _context;

        public RepositorioClientesEF()
        {
            this._context = new PapeleriaContext();
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

        public IEnumerable<Cliente> GetClientesPorPedido(IEnumerable<Pedido> pedidos)
        {
            var clienteIdsInPedidos = pedidos.Select(p => p.ClienteId).Distinct();
            var clientesFiltrados = _context.Clientes.Where(c => clienteIdsInPedidos.Contains(c.Id));

            return clientesFiltrados;
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

