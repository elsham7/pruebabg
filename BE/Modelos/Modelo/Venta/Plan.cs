using System.ComponentModel.DataAnnotations;

namespace Modelo.Venta
{
    public class Plan
    {
        [Key]
        public int IdPlan { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, MaxLength(255)]
        public string Descripcion { get; set; }

        [Required, MaxLength(1)]
        public string Frecuencia { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}
