using System;
using BussinessLogic.Entidades;

namespace AppLogic.DTOs
{
    public class PedidoDTO
    {
        public int Id { get; private set; }
        public int Recargo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaPrometida { get; set; }
        public double MontoTotal { get; set; }
        public int ClienteId { get; set; }
        public List<LineaDTO> Lineas { get; set; }
        public bool EsPedidoExpress { get; set; } = false;

        public PedidoDTO()
        {
        }

        public PedidoDTO(Pedido pedido)
        {
            if (pedido != null)
            {
                this.Recargo = pedido.Recargo;
                this.FechaPrometida = pedido.FechaPrometida;
                this.Fecha = pedido.Fecha;
                this.ClienteId = pedido.ClienteId;
            }
        }
    }
}

