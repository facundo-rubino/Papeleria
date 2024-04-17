using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Articulo
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public string Codigo { get; private set; }
        public int PrecioUnitario { get; private set; }
        public int Stock { get; private set; }

        public Articulo()
        {
        }
    }
}

