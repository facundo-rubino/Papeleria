using System;
using AppLogic.DTOs;

namespace AppLogic.InterfacesCU.Articulos
{
    public interface IFindAllArticulosPaginado
    {
        public IEnumerable<ArticuloDTO> FindAllPaginado(int pag);
    }
}

