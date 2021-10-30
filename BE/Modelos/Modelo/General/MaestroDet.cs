#region Using
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace Modelo.General
{
    public class MaestroDet
    {
        [Key, Column(Order = 1)]
        public int idMaestro { get; set; }
        [Key, Column(Order = 2)]
        public int Secuencia { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public string Estado { get; set; }
    }
}
