using System;
using System.ComponentModel.DataAnnotations;
using BussinessLogic.Excepciones;
using BussinessLogic.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    [Index(nameof(Codigo), IsUnique = true)]
    public class Articulo : IEquatable<Articulo>, IValidable<Articulo>
    {
        public int Id { get; private set; }
        [StringLength(200, MinimumLength = 10, ErrorMessage = "El nombre debe tener entre 10-200 caracteres")]
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }

        [StringLength(13, MinimumLength = 13, ErrorMessage = "El código debe ser de 13 dígitos")]

        public string Codigo { get; private set; }
        public int PrecioUnitario { get; private set; }
        public int Stock { get; private set; }

        public Articulo()
        {
        }

        public Articulo(string nombre, string descripcion, string codigo, int precioUnitario, int stock)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Codigo = codigo;
            this.PrecioUnitario = precioUnitario;
            this.Stock = stock;
        }

        public bool Equals(Articulo? other)
        {
            return other == null ? throw new ArgumentNullException("Debe incluir el articulo a comparar") : this.Id == other.Id;
        }

        public void EsValido()
        {
            try
            {
                this._validarNombre();
                this._validarCodigo();
            }
            catch (Exception ex)
            {
                throw new ArticuloNoValidoException(ex.Message);
            }
        }

        private void _validarNombre()
        {
            if (this.Nombre == null) throw new ArticuloNoValidoException("El nombre no puede ser vacío");
            if (this.Nombre.Length <= 10) throw new ArticuloNoValidoException("El nombre no puede tener menos de 10 caracteres");
            if (this.Nombre.Length >= 200) throw new ArticuloNoValidoException("El nombre no puede tener más de 200 caracteres");

        }

        private void _validarCodigo()
        {
            if (this.Codigo == null) throw new ArticuloNoValidoException("El código no puede ser vacío");
            if (this.Codigo.Length != 13) throw new ArticuloNoValidoException("El código debe tener 13 dígitos");

        }


    }
}

