using System;
using BussinessLogic.Entidades;

namespace AppLogic.DTOs
{
    public class PedidoComunDTO
    {
        public int Id { get; private set; }
        public int Recargo { get; set; }
        public DateTime Fecha { get; set; }
        public int FechaPrometida { get; set; }
        public double MontoTotal { get; set; }
        public Cliente Cliente { get; set; }
        public List<LineaDTO> Lineas { get; set; }

        public PedidoComunDTO()
        {
        }

        public PedidoComunDTO(PedidoDTO pedido)
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

