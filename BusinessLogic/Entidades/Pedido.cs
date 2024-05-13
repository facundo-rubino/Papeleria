using System;

namespace BussinessLogic.Entidades
{
    public class Pedido
    {

        public int Id { get; private set; }
        public int Recargo { get; set; }
        public DateTime FechaPrometida { get; set; }
        public int Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> Lineas { get; set; }

        public Pedido()
        {
        }

        public Pedido(int recargo, DateTime fechaPrometida, int fecha, Cliente cliente)
        {
            Recargo = recargo;
            FechaPrometida = fechaPrometida;
            Fecha = fecha;
            Cliente = cliente;
        }
    }
}

