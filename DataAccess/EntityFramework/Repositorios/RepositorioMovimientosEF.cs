using System;
using BusinessLogic.Entidades;
using BusinessLogic.Excepciones;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioMovimientosEF : IRepositorioMovimientos
    {
        private PapeleriaContext _context;
        private IRepositorioSettings _settings;

        public RepositorioMovimientosEF(IRepositorioSettings settings)
        {
            this._context = new PapeleriaContext();
            this._settings = settings;
        }

        public void Add(Movimiento aAgregar)
        {
            try
            {
                aAgregar.EsValido(_settings);
                _context.Movimientos.Add(aAgregar);
                _context.SaveChanges();
            }
            catch (MovimientoNoValidoException exception)
            {
                throw exception;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Movimiento> FindAll()
        {
            return this._context.Movimientos.Include(m => m.Tipo);
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

        public bool TipoMovimientoEnUso(int tipoMovimientoId)
        {
            return _context.Movimientos.Any(m => m.TipoId == tipoMovimientoId);
        }
    }
}

