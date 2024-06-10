using System;
using System.ComponentModel.DataAnnotations.Schema;
using BussinessLogic.Entidades;

namespace BusinessLogic.Entidades
{
    public class Movimiento
    {
        public int Id { get; private set; }
        public DateTime FechaHora { get; set; }
        [ForeignKey(nameof(Articulo))] public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        [ForeignKey(nameof(Usuario))] public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey(nameof(Tipo))] public int TipoId { get; set; }
        public TipoMovimiento Tipo { get; set; }
        public int Cant { get; set; }

        public Movimiento()
        {
        }


        public Movimiento(DateTime fechaHora, int articuloId, int usuarioId, int tipoId, int cant)
        {
            this.FechaHora = fechaHora;
            this.ArticuloId = articuloId;
            this.UsuarioId = usuarioId;
            this.TipoId = tipoId;
            this.Cant = cant;
        }
    }
}

