using System;
using BusinessLogic.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using AppLogic.DTOs;
using AppLogic.Mappers;
using BusinessLogic.InterfacesRepositorio;
using AppLogic.InterfacesCU.Movimientos;

namespace AppLogic.CasosDeUso.Movimientos
{
    public class ObtenerAgrupadosCU : IObtenerAgrupados
    {
        private IRepositorioMovimientos _repositorioMovimientos;

        public ObtenerAgrupadosCU(IRepositorioMovimientos repositorioMovimientos)
        {
            this._repositorioMovimientos = repositorioMovimientos;
        }

        public IEnumerable<ResumenMovimientoDTO> GetResumenMovimientos()
        {
            var movimientos = _repositorioMovimientos.FindAll();

            return movimientos.GroupBy(m => new { m.FechaHora.Year, m.Tipo.Nombre })
           .Select(g => new
           {
               Año = g.Key.Year,
               Tipo = g.Key.Nombre,
               Cantidad = g.Sum(m => m.Cant)
           })
           .GroupBy(r => r.Año)
           .Select(g => new ResumenMovimientoDTO
           {
               Anio = g.Key,
               Detalles = g.Select(x => new DetalleMovimientoDTO { Tipo = x.Tipo, Cantidad = x.Cantidad }).ToArray(),
               TotalAño = g.Sum(x => x.Cantidad)
           })
           .ToList();
        }


    }
}

