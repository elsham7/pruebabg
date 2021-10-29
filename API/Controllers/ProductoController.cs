using API.Util;
using LogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ModeloVista;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductoController : Controller
    {
        #region Método Inicial
        private LoginUserVM user = null;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = Request?.Headers["Authorization"].ToString().Replace("Bearer ", "");
            user = ConfigApp.UsuarioSolicitud(token);
        }
        #endregion

        #region Productos
        [HttpPost]
        [Route("listado-productos")]
        public async Task<List<ProductoVM>> ListadoPoductos()
        {           
            return await new BProducto().Listado();
        }
        #endregion
    }
}
