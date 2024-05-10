using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioSetttingsEF : IRepositorioSettings
    {
        private PapeleriaContext _context;
        public RepositorioSetttingsEF()
        {
            this._context = new PapeleriaContext();
        }
        public double GetValueByName(string name)
        {
            return _context.Settings.Where(setting => setting.Nombre == name).FirstOrDefault().Valor;
        }
        public bool Add(Setting aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Setting> FindAll()
        {
            throw new NotImplementedException();
        }

        public Setting FindByID(int id)
        {
            throw new NotImplementedException();
        }


        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Setting aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
