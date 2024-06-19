using System;
using BusinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace BusinessLogic.InterfacesRepositorio
{
    public interface IRepositorioMovimientos : IRepositorio<Movimiento>
    {
        public bool TipoMovimientoEnUso(int tipoMovimientoId);
        public IEnumerable<Movimiento> GetMovimientosPorArticuloTipo(int articuloId, int tipoId);
    }
}

