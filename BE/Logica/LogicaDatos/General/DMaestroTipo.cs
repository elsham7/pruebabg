#region Using
using Microsoft.EntityFrameworkCore;
using ViewModel.General;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace LogicaDatos.General
{
    public class DMaestroTipo
    {
        public async static Task<List<MaestroVM>> Listado(int idEmpresa, int[] tipos, string idPadre, string ordenarPor)
        {
            List<MaestroVM> lstMaestro = new List<MaestroVM>();

            using (DB db = new DB())
            {
                lstMaestro = await (from mt in db.GenMaestroDet
                                    where tipos.Contains(mt.idMaestro) && mt.Estado == "A"
                                    orderby (mt.Descripcion)
                                    select new MaestroVM
                                    {
                                        Tipo = mt.idMaestro.ToString(),
                                        Codigo = mt.Codigo,
                                        Descripcion = mt.Descripcion
                                    }).ToListAsync();
            }

            return lstMaestro;
        }
        
    }
}
