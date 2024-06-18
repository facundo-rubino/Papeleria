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
        private IObtenerMovimientos _obtenerMovimientosCU;

        public ObtenerAgrupadosCU(IObtenerMovimientos obtenerMovimientosCU)
        {
            this._obtenerMovimientosCU = obtenerMovimientosCU;
        }

        public IEnumerable<ResumenMovimientoDTO> GetResumenMovimientos()
        {
            IEnumerable<MovimientoDTO> movimientos = this._obtenerMovimientosCU.ObtenerMovimientos();

            return movimientos
                .GroupBy(movimiento => movimiento.FechaHora.Year)
                .Select(resumenGroup => new ResumenMovimientoDTO
                {
                    Anio = resumenGroup.Key,
                    Detalles = resumenGroup.GroupBy(resumen => resumen.Tipo.Nombre)
                                .Select(tipoGroup => new DetalleMovimientoDTO
                                {
                                    Tipo = tipoGroup.Key,
                                    Cantidad = tipoGroup.Sum(m => m.Cant)
                                }).ToArray(),
                    TotalAnio = resumenGroup.Sum(m => m.Cant)
                })
                .ToList();
        }


    }
}

