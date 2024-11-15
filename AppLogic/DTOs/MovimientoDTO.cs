using System;
using BusinessLogic.Entidades;
using BussinessLogic.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using AppLogic.Mappers;

namespace AppLogic.DTOs
{
    public class MovimientoDTO
    {
        public int Id { get; private set; }
        public DateTime FechaHora { get; set; }
        public int ArticuloId { get; set; }
        public Articulo? Articulo { get; set; }
        public string EmailUsuario { get; set; }
        public TipoMovimientoDTO? Tipo { get; set; }
        public int TipoId { get; set; }
        public int Cant { get; set; }


        public MovimientoDTO()
        {
        }

        public MovimientoDTO(Movimiento movimiento)
        {
            this.Id = movimiento.Id;
            this.FechaHora = movimiento.FechaHora;
            this.Articulo = movimiento.Articulo;
            this.EmailUsuario = movimiento.EmailUsuario;
            this.Tipo = TipoMovimientoDTOMapper.ToDto(movimiento.Tipo);
            this.Cant = movimiento.Cant;
        }




    }
}

