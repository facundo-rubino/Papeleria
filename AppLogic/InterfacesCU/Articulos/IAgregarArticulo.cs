using AppLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.InterfacesCU.Articulos
{
    public interface IAgregarArticulo
    {
        public void AgregarArticulo(ArticuloDTO aAgregar);
    }
}
