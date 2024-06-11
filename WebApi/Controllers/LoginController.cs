using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AppLogic.DTOs;
using ApplicationLogic.UseCases;
using AppLogic.DTOs;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<UsuarioDTO> Login([FromBody] UsuarioDTO usuario)
        {
            try
            {
                //A los efectos de la presente guía se obtiene directamente el usuario desde el
                //ManejadorJwt. En la aplicación se lo pediríamos al caso de uso que corresponda
                //que a su vez se lo pediría al repositorio, que lo obtendría desde la base de
                //datos a través de EF
                ManejadorJwt.CargarDatos();
                var usr = ManejadorJwt.ObtenerUsuario(usuario.Email);
                if (usr == null || usr.Password != usuario.Password)
                    return Unauthorized("Credenciales inválidas. Reintente");
                //Le pedimos al manejador de tokens que nos genere un token jwt con
                //la información del usuario para usar como claims (el email y el nombre de rol)
                //En caso de que se autentique, retorna el token y el usuario
                var token = ManejadorJwt.GenerarToken(usr);
                return Ok(new
                {
                    Token = token,
                    Usuario = usr
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    Message = "Se produjo un error.Intente n"
                });
            }
        }

    }
}
