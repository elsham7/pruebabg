using System.ComponentModel.DataAnnotations;

namespace AccesoDatos
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required,MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string Password { get; set; }

        [Required, MaxLength(255)]
        public string Nombre { get; set; }

        [Required, MaxLength(100)]
        public string Telefono { get; set; }

        [Required]
        public int IdPlan { get; set; }

        [Required, MaxLength(1)]
        public string IdEstado { get; set; }
    }
}
