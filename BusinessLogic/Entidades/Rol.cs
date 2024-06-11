using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entidades
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    public Rol(string nombre)
    {
        this.Nombre = nombre;
    }
    }

}
