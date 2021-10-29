using AccesoDatos;
using ModeloVista;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class BProducto
    {
        public async Task<List<ProductoVM>> Listado()
        {
            return await new DProducto().Listado();
        }
    }
}
