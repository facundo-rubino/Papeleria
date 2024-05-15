using System;
using BussinessLogic.Entidades;

namespace AppLogic.DTOs
{
    public class PedidoExpressDTO
    {
        public int Id { get; private set; }
        public int Recargo { get; set; }
        public DateTime Fecha { get; set; }
        public double MontoTotal { get; set; }
        public int FechaPrometida { get; set; }
        public Cliente Cliente { get; set; }
        public List<LineaDTO> Lineas { get; set; }

        public PedidoExpressDTO()
        {
        }

        public PedidoExpressDTO(PedidoDTO pedido)
        {
            if (pedido != null)
            {
                this.Recargo = pedido.Recargo;
                this.Fecha = pedido.Fecha;
                this.FechaPrometida = pedido.FechaPrometida;
                this.Cliente = pedido.Cliente;
            }
        }
    }
}

