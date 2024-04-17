using System;
namespace BussinessLogic.Entidades
{
    public class ArticuloComun : Articulo
    {
        public int Recargo { get; private set; }
        public int Fecha { get; private set; }

        public ArticuloComun()
        {
        }
    }
}

