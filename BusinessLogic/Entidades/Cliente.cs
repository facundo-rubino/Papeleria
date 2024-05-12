using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using BussinessLogic.InterfacesEntidades;
using BussinessLogic.ValueObjects;

namespace BussinessLogic.Entidades
{
    [Index(nameof(RazonSocial), IsUnique = true)]
    public class Cliente : IValidable<Cliente>
    {
        public int Id { get; private set; }
        public NombreCompleto Contacto { get; private set; }
        public string RazonSocial { get; private set; }
        public string Rut { get; private set; }
        public Direccion Direccion { get; private set; }

        public Cliente()
        {
        }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}

