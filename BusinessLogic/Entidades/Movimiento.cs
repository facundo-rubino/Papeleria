using System;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessLogic.Excepciones;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;

namespace BusinessLogic.Entidades
{
    public class Movimiento
    {
        public int Id { get; private set; }
        public DateTime FechaHora { get; set; }
        [ForeignKey(nameof(Articulo))] public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public string EmailUsuario { get; set; }
        [ForeignKey(nameof(TipoMovimiento))] public int TipoId { get; set; }
        public TipoMovimiento Tipo { get; set; }
        public int Cant { get; set; }

        public Movimiento()
        {
        }


        public Movimiento(DateTime fechaHora, int articuloId, string email, int tipoId, int cant)
        {
            this.FechaHora = fechaHora;
            this.ArticuloId = articuloId;
            this.EmailUsuario = email;
            this.TipoId = tipoId;
            this.Cant = cant;
        }

        public void EsValido(IRepositorioSettings settingsRepository)
        {
            try
            {
                this._validarCantidad(settingsRepository);
            }
            catch (Exception ex)
            {
                throw new MovimientoNoValidoException(ex.Message);
            }
        }

        private void _validarCantidad(IRepositorioSettings settingsRepository)
        {
            if (this.Cant <= 0)
                throw new MovimientoNoValidoException("La cantidad debe ser mayor a 0");
            if (this.Cant > settingsRepository.GetValueByName("Tope"))
                throw new MovimientoNoValidoException("La cantidad no puede ser mayor a " + settingsRepository.GetValueByName("Tope"));
        }
    }
}

