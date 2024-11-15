using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.InterfacesCU.Usuarios
{
    public interface IGetUsersByName
    {
        public IEnumerable<ArticuloDTO> GetUsersByName(string name);

    }
}
