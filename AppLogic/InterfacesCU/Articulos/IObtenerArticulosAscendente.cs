using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Articulos
{
    public interface IObtenerArticulosAscendente
    {
        public IEnumerable<ArticuloDTO> ObtenerArticulosAscendente();
    }
}

