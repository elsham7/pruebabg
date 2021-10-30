using LogicaDatos.General;
using ViewModel.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicaNegocio.General
{
    public class BMaestroTipo
    {
        public async static Task<List<MaestroVM>> Listado(int idEmpresa, int[] tipos, string idPadre, string ordenarPor) {
            return await DMaestroTipo.Listado(idEmpresa, tipos, idPadre, ordenarPor);
        }

    }
}
