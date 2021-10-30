using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDatos.General
{
    public class DParametro
    {
        public async static Task<string> Consultar(int idParametro)
        {
            string valor = "";

            using (DB db = new DB())
            {
                valor = await (from p in db.Parametro
                               where p.IdParametro == idParametro
                               select p.Valor).SingleOrDefaultAsync();
            }


            return valor;
        }
        
    }
}
