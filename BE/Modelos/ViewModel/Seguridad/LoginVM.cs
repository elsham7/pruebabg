using System.ComponentModel.DataAnnotations;

namespace ViewModel.Seguridad
{
    public class LoginVM
    {
        [Required, DataType(DataType.EmailAddress), MaxLength(100)]
        public string Email { get; set; }

        [Required, StringLength(30), DataType(DataType.Password), MaxLength(100)]
        public string Password { get; set; }
    }
}
