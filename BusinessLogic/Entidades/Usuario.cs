using System;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using BussinessLogic.Excepciones;
using BussinessLogic.ValueObjects;
using BussinessLogic.InterfacesEntidades;
using System.Xml.Linq;

namespace BussinessLogic.Entidades
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : IValidable, IEquatable<Usuario>
    {
        public int Id { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string? HashedPass { get; set; }


        public Usuario()
        {
        }

        public Usuario(string nombre, string apellido, string email, string pass)
        {
            this.NombreCompleto = new NombreCompleto(nombre, apellido);
            this.Email = email;
            this.Pass = pass;
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
                this._validarEmail();
                this._validarPassword();
                this._validarNombre();
                this._validarApellido();
            }
            catch (Exception ex)
            {
                throw new UsuarioNoValidoException(ex.Message);
            }
        }

        private void _validarNombre()
        {
            if (this.NombreCompleto.Nombre == null) throw new UsuarioNoValidoException("El nombre no puede ser vacío");
            if (!this._validarNombreApellido(this.NombreCompleto.Nombre)) throw new UsuarioNoValidoException("El nombre no puede contener caracteres especiales ni inicio ni al final");
        }

        private void _validarApellido()
        {
            if (this.NombreCompleto.Apellido == null) throw new UsuarioNoValidoException("El apellido no puede ser vacío");
            if (!this._validarNombreApellido(this.NombreCompleto.Apellido)) throw new UsuarioNoValidoException("El apellido no puede contener caracteres especiales ni inicio ni al final");
        }

        private void _validarEmail()
        {
            if (this.Email == null) throw new UsuarioNoValidoException("El email no puede ser vacío");
            // Expresión regular para chequear si el mail contiene catacteres no alfabéticos en los bordes 
            string regex = @"^[^a-zA-Z]+@.*$";
            //Comparo el email con la expresión regular
            if (Regex.IsMatch(this.Email, regex)) throw new UsuarioNoValidoException("El email es inválido"); ;
        }

        private void _validarPassword()
        {
            if (string.IsNullOrEmpty(this.Pass)) throw new UsuarioNoValidoException("Por favor ingrese una contraseña");

            if (this.Pass.Length <= 6) throw new UsuarioNoValidoException("La contraseña debe ser de al menos 6 caracteres");

            if (!this.Pass.Any(char.IsDigit)) throw new UsuarioNoValidoException("La contraseña debe contener al menos 1 número");

            if (!_contieneCaracteresAlfabeticos(this.Pass)) throw new UsuarioNoValidoException("La contraseña debe contener al menos 1 caracter especial");
        }

        private bool _validarNombreApellido(string input)
        {
            // ^[a-zA-Z] : Regex para que empiece con un caracter alfabético
            // [a-zA-Z'-]* : Regex para que contenga solo caracteres alfabéticos, apóstrofes y guiones
            // [a-zA-Z]$ : Regex para que termine con un caracter alfabético
            Regex validNameRegex = new Regex("^[a-zA-Z][a-zA-Z'-]*[a-zA-Z]$");
            // comparamos y devolvemos el booleano
            return validNameRegex.IsMatch(input);
        }
        private bool _contieneCaracteresAlfabeticos(string input)
        {
            //Si devuelve true significa que no tiene caracteres no alfabeticos
            string regex = @"[^a-zA-Z0-9]"; // Expresión regular para buscar solo caracteres alfabéticos
            return Regex.IsMatch(input, regex); // comparo el regex con el input 
        }
    }
}

