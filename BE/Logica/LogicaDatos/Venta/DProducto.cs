using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities;
using ViewModel;
using ViewModel.Venta;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LogicaDatos.Venta
{
    public class DProducto
    {
        public async Task<List<ProductoVM>> Listado()
        {

            MySqlConnection con = await DB.GetConnection();
            List<ProductoVM> listado = new List<ProductoVM>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spListadoProducto";
                cmd.Parameters.AddWithValue("@idEstado", EstadoProducto.Activo);

                var dr = await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    listado.Add(new ProductoVM
                    {
                        Descripcion = Comun.ToString(dr["Descripcion"]),
                        Detalle = Comun.ToString(dr["Detalle"]),
                        IdEstado = Comun.ToString(dr["IdEstado"]),
                        IdProducto = Comun.ToInt(dr["IdProducto"]),
                        Precio = Comun.ToDecimal(dr["Precio"]),
                        UrlImagen = Comun.ToString(dr["UrlImagen"]),
                    });
                }

                dr.Close();
            }
            finally
            {
                await con.CloseAsync();
            }

            return listado;
        }

        public async Task<CarritoVM> ConsultarCarrito(List<ItemCarritoVM> items)
        {
            CarritoVM carrito = new CarritoVM();
            decimal totalGeneral = 0;
            decimal totalLinea = 0;

            using (DB db = new DB())
            {
                foreach (var item in items)
                {
                    // Se recomienda SP, se utiliza EF por tiempo
                    var producto = await db.Producto.Where(x => x.IdProducto == item.IdProducto).FirstOrDefaultAsync();

                    if (producto != null)
                    {
                        totalLinea = item.Cantidad * producto.Precio;
                        totalGeneral += totalLinea;

                        carrito.Items.Add(new ItemCarritoVM
                        {
                            Cantidad = item.Cantidad,
                            IdProducto = item.IdProducto,
                            Producto = item.Producto,
                            Total = totalLinea
                        });
                    }
                }

                carrito.Total = totalGeneral;
            }

            return carrito;
        }
    }
}
