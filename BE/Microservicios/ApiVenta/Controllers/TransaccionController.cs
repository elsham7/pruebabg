using LogicaNegocio.Venta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Venta;

namespace ApiVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionController : ControllerBase
    {
        private readonly IDistributedCache cache;

        public TransaccionController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        [HttpPost]
        [Route("listado-productos")]
        public async Task<List<ProductoVM>> ListadoProductos()
        {
            return await new BProducto(cache).Listado();
        }
        
        [HttpPost]
        [Route("consultar-carrito")]
        public async Task<CarritoVM> ConsultarCarrito(List<ItemCarritoVM> items)
        {
            return await new BProducto().ConsultarCarrito(items);
        }
    }
}
