using BusinessLogic.Entidades;
using BussinessLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.DTOs
{
    public class RolDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public RolDTO() { }

        public RolDTO(string nombre)
        {
            if (nombre != null)
            {
                this.Nombre = nombre;
            }
        }
    }
}
