using BusinessLogic.Excepciones;
using BusinessLogic.InterfacesRepositorio;
using System;
using System.Numerics;

namespace BussinessLogic.Entidades
{
    public class PedidoComun : Pedido
    {
        public PedidoComun()
        {
        }

        public override void EsValido(IRepositorioSettings settingsRepository)
        {
            this._validarFechaPrometida();
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
            double recargo = settingsRepository.GetValueByName("RecargoPedidoComun");
            if (base.Cliente.Direccion.Distancia > 100)
            {
                base.MontoTotal += (base.MontoTotal * recargo) / 100;
            }
        }

        public override void CalcularIVA(IRepositorioSettings settingsRepository)
        {
            double valorIVA = settingsRepository.GetValueByName("IVA");
            base.MontoTotal += (base.MontoTotal * valorIVA) / 100;
        }

        private void _validarFechaPrometida()
        {
            if (base.FechaPrometida < 8)
                throw new PedidoNoValidoException("La fecha prometida no puede ser menor a una semana");
        }


    }
}
