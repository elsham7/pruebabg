using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccesoDatos
{
    public class VentaDet
    {
        [Key, Column(Order = 1)]
        public int IdUsuario { get; set; }

        [Key, Column(Order = 2)]
        public int IdProducto { get; set; }
        public short Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
