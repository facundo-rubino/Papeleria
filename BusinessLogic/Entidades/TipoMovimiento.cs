using System;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class TipoMovimiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Signo { get; set; }

        public TipoMovimiento()
        {
        }

        public TipoMovimiento(string nombre, int signo)
        {
            this.Nombre = nombre;
            this.Signo = signo;
        }
    }
}

