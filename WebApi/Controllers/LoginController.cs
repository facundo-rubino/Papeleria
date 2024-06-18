using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Usuarios;
using BussinessLogic.InterfacesRepositorio;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IFindByEmail _findByEmailCU;
        private ILogin _loginUC;

        public LoginController(IFindByEmail findByEmail, ILogin loginUC)
        {
            this._findByEmailCU = findByEmail;
            this._loginUC = loginUC;
        }

        /// <summary>
        /// Metodo para permitir inicio de sesion y obtener un jwt para uso de la api
        /// </summary>
        /// <param name="email">email de usuario y contraseña</param>
        /// <returns>Token y datos del usuario</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<UsuarioDTO> Login(string email, string pass)
        {
            try
            {
                var usuario = this._findByEmailCU.GetUserByEmail(email);
                if (!_loginUC.LoginIsValid(email, pass))
                    return Unauthorized("Credenciales inválidas.");
                //Le pedimos al manejador de tokens que nos genere un token jwt con
                //la información del usuario para usar como claims (el email y el nombre de rol)
                //En caso de que se autentique, retorna el token y el usuario
                var token = ManejadorJwt.GenerarToken(usuario);

                return Ok(new
                {
                    Token = token,
                    Usuario = usuario
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    Message = "Se produjo un error. Intente nuevamente"
                });
            }
        }

    }
}
