using System;
using AppLogic.DTOs;
using BussinessLogic.Entidades;

namespace AppLogic.InterfacesCU.Articulos
{
    public interface IArticulosPorFecha
    {
        public IEnumerable<ArticuloDTO> ArticulosPorFecha(DateTime fechaIni, DateTime fechaFin);
    }
}

