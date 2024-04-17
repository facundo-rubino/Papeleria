using System;
namespace AppLogic.InterfacesCU.Usuarios
{
    public interface ILogin
    {
        public bool LoginIsValid(string user, string pass);
    }
}

