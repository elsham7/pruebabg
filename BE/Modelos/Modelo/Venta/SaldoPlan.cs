using System.ComponentModel.DataAnnotations;

namespace Modelo.Venta
{
    public class SaldoPlan
    {
        [Key]
        public int IdUsuario { get; set; }
        public decimal Saldo { get; set; }
        public string Periodo { get; set; }
    }
}
