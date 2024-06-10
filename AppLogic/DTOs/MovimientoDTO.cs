using System;
using BusinessLogic.Entidades;
using BussinessLogic.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppLogic.DTOs
{
    public class MovimientoDTO
    {
        public int Id { get; private set; }
        public DateTime FechaHora { get; set; }
        public int ArticuloId { get; set; }
        public int UsuarioId { get; set; }
        public int TipoId { get; set; }
        public int Cant { get; set; }



        public MovimientoDTO()
        {
        }

        public MovimientoDTO(Movimiento movimiento)
        {
            this.Id = movimiento.Id;
            this.FechaHora = movimiento.FechaHora;
            this.ArticuloId = movimiento.ArticuloId;
            this.UsuarioId = movimiento.UsuarioId;
            this.TipoId = movimiento.TipoId;
            this.Cant = movimiento.Cant;
        }




    }
}

