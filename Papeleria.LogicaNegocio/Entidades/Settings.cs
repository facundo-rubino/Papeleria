using System;
using System.Drawing;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Settings
    {
        public double ValorIVA { get; private set; }
        public int PlazoComun { get; private set; }
        public int PlazoExpress { get; private set; }

        public Settings()
        {
        }

        public void EsValido()
        {

        }

        public void SetIVA(double valor)
        {
            this.ValorIVA = valor;
        }

        public void SetPLazoComun(int valor)
        {
            this.PlazoComun = valor;
        }

        public void SetPLazoExpress(int valor)
        {
            this.PlazoExpress = valor;
        }
    }
}

