#region Using
using System.ComponentModel.DataAnnotations; 
#endregion

namespace Modelo.General
{
    public class MaestroCab
    {
        [Key, Required]
        public int idMaestro { get; set; }      

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Estado { get; set; }
    }
}
