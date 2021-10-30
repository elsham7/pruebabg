using ConLogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ApiComun.Utilities;
using LogicaNegocio.General;
using Utilities;
using ViewModel.General;
using ViewModel.Seguridad;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ApiGeneral.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MantenimientoController : Controller
    {
        #region Método Inicial
        private LoginUserVM user = null;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = Request?.Headers["Authorization"].ToString().Replace("Bearer ", "");
            user = ConfigApp.UsuarioSolicitud(token);
        } 
        #endregion
       
    }
}
