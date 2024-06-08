using BusinessLogic.Entidades;
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
            catch (UsuarioNoValidoException exception)
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
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoMovimiento aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
