using System;
using BussinessLogic.Entidades;

namespace AppLogic.DTOs
{
    public class PedidoComunDTO
    {
        public int Id { get; private set; }
        public int Recargo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaPrometida { get; set; }
        public double MontoTotal { get; set; }
        public int ClienteId { get; set; }
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
                this.ClienteId = pedido.ClienteId;
                this.Lineas = pedido.Lineas;
            }
        }
    }
}

