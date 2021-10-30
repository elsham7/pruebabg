using ApiComun.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using ViewModel.Seguridad;

namespace ApiVenta.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoController : Controller
    {
        #region Método Inicial
        private LoginUserVM user = null;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = Request?.Headers["Authorization"].ToString().Replace("Bearer ", "");
            user = ConfigApp.UsuarioSolicitud(token);
        }
        #endregion    

        [HttpPost]
        [Route("grabar-carrito")]
        public async Task GrabarCarrito() { 
        
        }
    }
}
