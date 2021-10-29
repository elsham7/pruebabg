using API.Util;
using LogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModeloVista;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]/[action]")]    
    public class SeguridadController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SeguridadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {           

            #region Log de acceso
            //await BLog.Acceso(idEmpresa, 0, ApiModulo.Seguridad.ToString(), new StackTrace());
            #endregion

            var userAdmin = await new BUsuario().Login(login);

            // Se genera el token
            if (userAdmin != null)
            {
                userAdmin.TokenRefresh = JWT.GenerarRefreshToken();

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name,login.Email),                   
                    new Claim("IdUsuario",userAdmin.IdUsuario.ToString()),
                    new Claim("TokenRefresh",userAdmin.TokenRefresh)
                };

                userAdmin.Token = JWT.GenerarToken(claims);
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
