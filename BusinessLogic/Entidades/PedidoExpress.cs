using BusinessLogic.Excepciones;
using BussinessLogic.InterfacesRepositorio;
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
            ValidarFechaPrometida(settingsRepository);
        }

        public override void CalcularCostosExtra(IRepositorioSettings settingsRepository)
        {
            CalcularMontoTotal();
            CalcularRecargo(settingsRepository);
            CalcularIVA(settingsRepository);
        }


        public override void CalcularMontoTotal()
        {
            double montoTotal = 0;
            foreach (var linea in base.Lineas)
            {
                double montoLinea = linea.Precio * linea.Cantidad;
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

        public override void ValidarFechaPrometida(IRepositorioSettings settingsRepository)
        {
            double plazo = settingsRepository.GetValueByName("PlazoPedidoExpress");

            TimeSpan dias = base.FechaPrometida - base.Fecha;

            if (dias.TotalDays > plazo)
                throw new PedidoNoValidoException("El plazo para entregar el pedido no puede ser mayor a " + plazo);
        }

    }

}

