using LogicaDatos.General;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace LogicaNegocio.General
{
    public class BParametro
    {
        private DParametro dal = new DParametro();
        
        public async static Task<string> Consultar(int idParametro)
        {
            return await DParametro.Consultar(idParametro);
        }

    }
}
