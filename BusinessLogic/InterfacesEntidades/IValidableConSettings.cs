using System;
using BusinessLogic.InterfacesRepositorio;

namespace BusinessLogic.InterfacesEntidades
{
    public interface IValidableConSettings
    {
        public void EsValido(IRepositorioSettings settingsRepository);
    }

}

