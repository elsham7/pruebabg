using System.ComponentModel.DataAnnotations;

namespace AccesoDatos
{
    public class VentaCab
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public decimal Total { get; set; }
    }
}
