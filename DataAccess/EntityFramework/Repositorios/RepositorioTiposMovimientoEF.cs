using BusinessLogic.Entidades;
using BusinessLogic.InterfacesRepositorio;
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
            throw new NotImplementedException();
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
