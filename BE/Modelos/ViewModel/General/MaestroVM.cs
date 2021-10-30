using System.Collections.Generic;
using System.Linq;

namespace ViewModel.General
{
    public class MaestroVM
    {
        public string Tipo { get; set; }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public static List<MaestroVM> GetType(ref List<MaestroVM> list, string type)
        {
            return list.Where(x => x.Tipo == type).ToList();
        }
       
    }
}
