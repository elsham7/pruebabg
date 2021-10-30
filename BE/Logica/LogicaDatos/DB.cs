using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Modelo.General;
using Modelo.Seguridad;
using Utilities;
using System;
using Modelo.Venta;
using System.Threading.Tasks;

namespace LogicaDatos
{
    public class DB : DbContext
    {       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region GENERAL            
            modelBuilder.Entity<MaestroDet>().HasKey(c => new { c.idMaestro, c.Secuencia });
            #endregion

            #region VENTA            
            modelBuilder.Entity<VentaDet>().HasKey(c => new { c.IdUsuario, c.IdProducto });
            #endregion


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 22));

            var ambiente = Comun.ConfigApp.GetSection("AMBIENTE").Value;
            var cadenaConexionBase = Comun.ConfigApp.GetSection("CADENA-CONEXION-BASE-" + ambiente).Value;

            optionsBuilder.UseMySql(cadenaConexionBase, serverVersion);
            optionsBuilder.EnableDetailedErrors(true);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }        

        #region GENERAL
        public DbSet<MaestroCab> GenMaestroCab { get; set; }
        public DbSet<MaestroDet> GenMaestroDet { get; set; }
        public DbSet<Parametro> Parametro { get; set; }
        #endregion       

        #region SEGURIDAD
        public DbSet<Usuario> SegUsuario { get; set; }
        #endregion

        #region VENTA
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<SaldoPlan> SaldoPlan { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<VentaCab> VentaCab { get; set; }
        public DbSet<VentaDet> VentaDet { get; set; }
        #endregion

        public static async Task<MySqlConnection> GetConnection() {
            var ambiente = Comun.ConfigApp.GetSection("AMBIENTE").Value;
            var cadenaConexionBase = Comun.ConfigApp.GetSection("CADENA-CONEXION-BASE-" + ambiente).Value;
            MySqlConnection conn = new MySqlConnection(cadenaConexionBase);
            await conn.OpenAsync();

            return conn;
        }
    }
}
