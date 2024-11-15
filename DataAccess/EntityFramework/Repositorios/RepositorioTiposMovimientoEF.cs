using BusinessLogic.Entidades;
using BusinessLogic.Excepciones;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.Excepciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioTiposMovimientoEF : IRepositorioTiposMovimiento
    {
        private PapeleriaContext _context;

        public RepositorioTiposMovimientoEF()
        {
            this._context = new PapeleriaContext();
        }

        public void Add(TipoMovimiento aAgregar)
        {
            try
            {
                _context.TiposMovimiento.Add(aAgregar);
                _context.SaveChanges();
            }
            catch (TipoMovimientoNoValidoException exception)
            {
                throw exception;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TipoMovimiento> FindAll()
        {
            return this._context.TiposMovimiento;
        }

        public TipoMovimiento FindByID(int id)
        {
            return this._context.TiposMovimiento.Where(tipoMov => tipoMov.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            TipoMovimiento toRemove = new TipoMovimiento { Id = id };
            this._context.TiposMovimiento.Remove(toRemove);
            this._context.SaveChanges();
        }

        public void Update(TipoMovimiento aActualizar)
        {
            this._context.TiposMovimiento.Update(aActualizar);
            this._context.SaveChanges();
        }
    }
}
