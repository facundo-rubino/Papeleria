using System;
using BussinessLogic.Entidades;

namespace BussinessLogic.InterfacesRepositorio
{
    public interface IRepositorioArticulos : IRepositorio<Articulo>
    {
        public IEnumerable<Articulo> GetArticulosPorMovimientoFecha(DateTime fechaIni, DateTime fechaFin);
    }
}

