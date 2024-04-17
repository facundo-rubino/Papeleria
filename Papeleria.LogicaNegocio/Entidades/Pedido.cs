using System;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Pedido
    {

        public int Id { get; private set; }
        public int Recargo { get; private set; }
        public DateTime FechaPrometida { get; private set; }
        public int Fecha { get; private set; }
        public Cliente Cliente { get; private set; }
        public List<Linea> Lineas { get; private set; }


        public Pedido()
        {
        }
    }
}

