using System;
using BusinessLogic.Entidades;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.InterfacesRepositorio;
using static System.Formats.Asn1.AsnWriter;

namespace DataAccess.EntityFramework.Repositorios
{
    public class RepositorioMovimientosEF : IRepositorioMovimientos
    {
        private PapeleriaContext _context;

        public RepositorioMovimientosEF()
        {
            this._context = new PapeleriaContext();
        }

        public void Add(Movimiento aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movimiento> FindAll()
        {
            return this._context.Movimientos;
        }

        public Movimiento FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Movimiento aModificar)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable ObtenerMovimientosPorAnio()
        //{

        //    IEnumerable<Movimiento> movimientos = this.FindAll();

        //    return movimientos.GroupBy(movimientos => movimientos.FechaHora.Year)
        //        .Select(movimientoGroup => new
        //        {
        //            Cantidad = movimientoGroup.Count(),
        //            Tipo = movimientoGroup.SelectMany(mov => mov.Tipo)
        //                .GroupBy(scores => scores.TeamId)
        //                .Select(teamScore => new
        //                {
        //                    TeamId = teamScore.Key,
        //                    TotalAnio = teamScore.Sum(result => result.Score)
        //                })
        //        });
        //}
    }
}

