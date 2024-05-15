﻿using BusinessLogic.Excepciones;
using BusinessLogic.InterfacesRepositorio;
using System;
namespace BussinessLogic.Entidades
{
    public class PedidoExpress : Pedido
    {
        public PedidoExpress()
        {
        }

        public override void EsValido(IRepositorioSettings settingsRepository)
        {
            _validarFechaPrometida(settingsRepository);
        }

        public override void CalcularMontoTotal()
        {
            double montoTotal = 0;
            foreach (var linea in base.Lineas)
            {
                double montoLinea = linea.Articulo.PrecioUnitario * linea.Cantidad;
                montoTotal += montoLinea;
            }

            base.MontoTotal = montoTotal;
        }

        public override void CalcularRecargo(IRepositorioSettings settingsRepository)
        {
            double recargo = settingsRepository.GetValueByName("RecargoPedidoExpress");
            double recargoExtra = settingsRepository.GetValueByName("RecargoExtraPedidoExpress");

            if (base.Fecha == DateTime.Today)
                base.MontoTotal += (base.MontoTotal * recargoExtra) / 100;
            else
                base.MontoTotal += (base.MontoTotal * recargo) / 100;
        }

        public override void CalcularIVA(IRepositorioSettings settingsRepository)
        {
            double valorIVA = settingsRepository.GetValueByName("IVA");
            base.MontoTotal += (base.MontoTotal * valorIVA) / 100;
        }

        private void _validarFechaPrometida(IRepositorioSettings settingsRepository)
        {
            double plazo = settingsRepository.GetValueByName("PlazoPedidoExpress");

            if (base.FechaPrometida > plazo)
                throw new PedidoNoValidoException("La fecha prometida no puede ser mayor a " + plazo + " que es el plazo estipulado");
        }

    }

}

