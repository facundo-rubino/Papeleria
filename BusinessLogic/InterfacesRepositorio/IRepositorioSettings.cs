using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.InterfacesRepositorio
{
    public interface IRepositorioSettings : IRepositorio<Setting>
    {
        public double GetValueByName(string name);
    }
}
