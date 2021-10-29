using System.ComponentModel.DataAnnotations;

namespace ModeloVista
{
    public class LoginVM
    {
        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, StringLength(255), DataType(DataType.Password)]
        public string Password { get; set; }       
    }
}
