using System;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using BussinessLogic.Excepciones;
using BussinessLogic.ValueObjects;

namespace BussinessLogic.Entidades
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        public int Id { get; private set; }
        public NombreCompleto NombreCompleto { get; private set; }
        public string Email { get; private set; }
        public string Pass { get; private set; }
        public string? HashedPass { get; private set; }


        public Usuario()
        {
        }

        public Usuario(string nombre, string apellido, string email, string pass, string unencryptedPass)
        {
            this.NombreCompleto = new NombreCompleto(nombre, apellido);
            this.Email = email;
            this.Pass = pass;
            this.HashedPass = unencryptedPass;
        }

        override public string ToString()
        {
            return $"{NombreCompleto.Nombre} -- {NombreCompleto.Apellido}";
        }
        public bool Equals(Usuario? other)
        {
            return other == null ? throw new ArgumentNullException("Debe incluir el usuario a comparar") : this.Id == other.Id;
        }

        public void EsValido()
        {
            try
            {
                this._validarNombre();
                this._validarApellido();
                this._validarEmail();
            }
            catch (Exception ex)
            {
                throw new UsuarioNoValidoException("Estoy capturando en EsValido", ex);
            }
        }

        private void _validarNombre()
        {
            if (this.NombreCompleto.Nombre == null) throw new UsuarioNoValidoException("El nombre no puede ser vacío");
            //if (_tieneCaracteresNoAlfabeticos(this.NombreCompleto.Nombre)) throw new UsuarioNoValidoException("El nombre no puede contener caracteres no alfabéticos");
        }

        private void _validarApellido()
        {
            if (this.NombreCompleto.Apellido == null) throw new UsuarioNoValidoException("El apellido no puede ser vacío");
            //if (_tieneCaracteresNoAlfabeticos(this.NombreCompleto.Apellido)) throw new UsuarioNoValidoException("El apellido no puede contener caracteres no alfabéticos");
        }

        private void _validarEmail()
        {
            if (this.Email == null) throw new UsuarioNoValidoException("El email no puede ser vacío");
            // Expresión regular para chequear si el mail contiene catacteres no alfabéticos en los bordes 
            string regex = @"^[^a-zA-Z]+@.*$";
            // Comparo el email con la expresión regular
            //  if (Regex.IsMatch(this.Email, regex)) throw new UsuarioNoValidoException("El email es inválido"); ;
        }

        private bool _tieneCaracteresNoAlfabeticos(string input)
        {
            string regex = "^[a-zA-Z]+$";  // Expresión regular para buscar solo caracteres alfabéticos
            return Regex.IsMatch(input, regex); // comparo el regex con el input 
        }
    }
}

