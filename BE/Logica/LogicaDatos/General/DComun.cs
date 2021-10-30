using Microsoft.EntityFrameworkCore;
using Utilities;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace LogicaDatos.General
{
    public class DComun
    {
        public static async Task<DateTime> FechaHoraSistema()
        {
            DateTime fechaHora = DateTime.Now;

            using (DB db = new DB())
            {
                var conn = db.Database.GetDbConnection();
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "select now() FechaHora ";
                    DbDataReader dr = await command.ExecuteReaderAsync();

                    if (dr.Read())
                    {
                        fechaHora = Comun.ToDate(dr["FechaHora"]);
                    }

                    dr.Close();

                }
            }

            return fechaHora;
        }
    }
}
