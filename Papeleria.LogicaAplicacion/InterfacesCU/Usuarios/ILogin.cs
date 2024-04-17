using System;
namespace Papeleria.LogicaAplicacion.InterfacesCU.Usuarios
{
    public interface ILogin
    {
        public bool LoginIsValid(string user, string pass);
    }
}

