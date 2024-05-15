using BusinessLogic.InterfacesEntidades;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.InterfacesRepositorio;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.Entidades
{
    public abstract class Pedido : IValidableConSettings
    {

        public int Id { get; private set; }
        public int Recargo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaPrometida { get; set; }
        public double MontoTotal { get; set; }
        [ForeignKey(nameof(Cliente))] public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> Lineas { get; set; }
        public bool EsPedidoExpress { get; set; } = false;

        public Pedido()
        {
        }

        public abstract void EsValido(IRepositorioSettings settingsRepository);

        public abstract void CalcularRecargo(IRepositorioSettings settingsRepository);

        public abstract void CalcularMontoTotal();

        public abstract void CalcularIVA(IRepositorioSettings settingsRepository);

        public abstract void ValidarFechaPrometida(IRepositorioSettings settingsRepository);


    }
}

