using System;
using BussinessLogic.InterfacesRepositorio;

namespace BusinessLogic.InterfacesEntidades
{
    public interface IValidableConSettings
    {
        public void EsValido(IRepositorioSettings settingsRepository);
    }

}

