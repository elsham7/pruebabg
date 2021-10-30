using System.ComponentModel.DataAnnotations;

namespace Modelo.General
{
    public class Parametro
    {
        [Key]
        public int IdParametro { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
    }
}
