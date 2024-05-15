using System;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Setting
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Valor { get; set; }

        public Setting()
        {
        }

        public void EsValido()
        {
            // this._validarIVA();
        }

        //private bool _validarIVA()
        //{
        //    return this.ValorIVA > 0;
        //}
    }
}

