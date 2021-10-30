using LogicaDatos.Venta;
using LogicaNegocio.General;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Venta;

namespace LogicaNegocio.Venta
{
    public class BProducto
    {
        private readonly IDistributedCache cache;

        #region Constructores
        public BProducto()
        {
        }

        public BProducto(IDistributedCache cache)
        {
            this.cache = cache;
        } 
        #endregion

        public async Task<List<ProductoVM>> Listado() {

            List<ProductoVM> productos;

            #region Revisar Cache y Consulta de Productos
            var datoCache = await cache.GetStringAsync("Productos");

            if (datoCache == null)
            {

                productos = await new DProducto().Listado();

                #region No Imagen
                var urlNoImagen = await BParametro.Consultar(1);
                foreach (var item in productos)
                {
                    if (string.IsNullOrEmpty(item.UrlImagen))
                    {
                        item.TieneImagen = false;
                        item.UrlImagen = urlNoImagen;
                    }
                    else
                        item.TieneImagen = true;
                }
                #endregion

                await cache.SetStringAsync("Productos", JsonConvert.SerializeObject(productos));
            }
            else
            {
                productos = JsonConvert.DeserializeObject<List<ProductoVM>>(datoCache);
            }
            #endregion           

            return productos;
        }

        public async Task<CarritoVM> ConsultarCarrito(List<ItemCarritoVM> items) {
            return await new DProducto().ConsultarCarrito(items);
        }
    }
}
