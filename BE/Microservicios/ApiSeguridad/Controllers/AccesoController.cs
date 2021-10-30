using ApiComun.Utilities;
using ConLogicaNegocio;
using LogicaNegocio.Seguridad;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utilities;
using ViewModel.Seguridad;

namespace ApiSeguridad.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccesoController : ControllerBase
    {
        private readonly IBusControl _bus;
        private readonly IConfiguration _configuration;
        public AccesoController(IConfiguration configuration, IBusControl bus)
        {
            _configuration = configuration;
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginVM login)
        {            

            #region Log de acceso
            await BLog.Acceso(0, ApiModulo.Seguridad.ToString(), new StackTrace(), _bus);
            #endregion

            var userAdmin = await new BSeguridad().Login(login);

            // Se genera el token
            if (userAdmin != null)
            {
                userAdmin.LoginUser.TokenRefresh = JWT.GenerarRefreshToken();

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name,login.Email),                    
                    new Claim("IdUsuario",userAdmin.LoginUser.IdUsuario.ToString()),
                    new Claim("TokenRefresh",userAdmin.LoginUser.TokenRefresh)
                };

                userAdmin.LoginUser.Token = JWT.GenerarToken(claims);
            }
            else
                return Unauthorized();

            return Ok(userAdmin);
        }


        [HttpPost]
        public IActionResult RefreshToken(RefreshTokenVM refreshRequest)
        {
            RefreshTokenVM nuevoToken = new RefreshTokenVM();

            if (refreshRequest.Token != null && refreshRequest.TokenRefresh != null)
            {
                var principal = JWT.ConsultarClaim(refreshRequest.Token);
                string tokenRefresh = principal.Claims.Where(x => x.Type == "TokenRefresh").Select(x => x.Value).FirstOrDefault();

                if (tokenRefresh != refreshRequest.TokenRefresh) return BadRequest();

                string nombre = principal.Identity.Name;                
                string idUsuario = principal.Claims.Where(x => x.Type == "IdUsuario").Select(x => x.Value).FirstOrDefault();

                nuevoToken.TokenRefresh = JWT.GenerarRefreshToken();

                var claims = new[]
                   {
                    new Claim(ClaimTypes.Name, nombre),
                    new Claim("IdUsuario",idUsuario),
                    new Claim("TokenRefresh",nuevoToken.TokenRefresh)
                };

                nuevoToken.Token = JWT.GenerarToken(claims);
            }
            else
                return BadRequest();

            return Ok(nuevoToken);
        }
    }

}
