using ApiComun.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ViewModel.Seguridad;

namespace ApiGeneral.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConsultaController : Controller
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
