using System;
using BussinessLogic.Entidades;

namespace AppLogic.DTOs
{
    public class PedidoComunDTO
    {
        public int Id { get; private set; }
        public int Recargo { get; set; }
        public DateTime FechaPrometida { get; set; }
        public int Fecha { get; set; }
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
                this.FechaPrometida = pedido.FechaPrometida;
                this.Fecha = pedido.Fecha;
                this.Cliente = pedido.Cliente;
            }
        }
    }
}

