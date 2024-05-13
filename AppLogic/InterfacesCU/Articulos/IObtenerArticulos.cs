using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Articulos
{
    public interface IObtenerArticulos
    {
        public IEnumerable<ArticuloDTO> ObtenerArticulos();
    }
}

