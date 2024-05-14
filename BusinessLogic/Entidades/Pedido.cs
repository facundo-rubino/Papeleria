using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.InterfacesRepositorio;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.Entidades
{
    public abstract class Pedido 
    {

        public int Id { get; private set; }
        public int Recargo { get; set; }
        public DateTime FechaPrometida { get; set; }
        public int Fecha { get; set; }
        [ForeignKey(nameof(Cliente))] public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> Lineas { get; set; }

        public Pedido()
        {
        }


        protected abstract void CalcularIVA(IRepositorioSettings repositorioSettings);

        //public Pedido(int recargo, DateTime fechaPrometida, int fecha, Cliente cliente)
        //{
        //    Recargo = recargo;
        //    FechaPrometida = fechaPrometida;
        //    Fecha = fecha;
        //    Cliente = cliente;
        //}
    }
}

