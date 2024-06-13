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

        public LoginController(IFindByEmail findByEmail)
        {
            this._findByEmailCU = findByEmail;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UsuarioDTO> Login([FromBody] UsuarioDTO usuarioDto)
        {
            try
            {
                var usuario = this._findByEmailCU.GetUserByEmail(usuarioDto.Email);
                if (usuario == null || usuario.Pass != usuarioDto.Pass)
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
