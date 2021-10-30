using LogicaDatos.General;
using System;
using System.Threading.Tasks;

namespace LogicaNegocio.General
{
    public class BComun
    {
        public static async Task<DateTime> FechaHoraSistema() {
            return await DComun.FechaHoraSistema();
        }
    }
}
