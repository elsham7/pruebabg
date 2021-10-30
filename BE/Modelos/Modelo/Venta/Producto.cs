using System.ComponentModel.DataAnnotations;

namespace Modelo.Venta
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required, MaxLength(100)]
        public string Descripcion { get; set; }

        [Required, MaxLength(255)]
        public string Detalle { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required, MaxLength(255)]
        public string UrlImagen { get; set; }

        [Required, MaxLength(1)]
        public string IdEstado { get; set; }
    }
}
