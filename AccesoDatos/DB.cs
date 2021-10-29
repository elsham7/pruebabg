using Microsoft.EntityFrameworkCore;
using System;
using Utilities;

namespace AccesoDatos
{
    public class DB : DbContext
    {
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region CARRITO            
            modelBuilder.Entity<CarritoDet>().HasKey(c => new { c.IdUsuario, c.IdProducto });
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
      

        #region CARRITO
        public DbSet<CarritoCab> CarritoCab { get; set; }
        public DbSet<CarritoDet> CarritoDet { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<SaldoPlan> SaldoPlan { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<VentaCab> VentaCab { get; set; }
        public DbSet<VentaDet> VentaDet { get; set; }
        #endregion


    }
}
