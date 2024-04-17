using Microsoft.EntityFrameworkCore;
using BussinessLogic.Entidades;

namespace DataAccess.EntityFramework
{
    public class PapeleriaContext : DbContext
    {

        // public DbSet<Articulo> Articulos { get; set; }
        // public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost,
                1433;
                Database=Papeleria_db;
                User=sa;
                Password=Desarrollo2024.;
                TrustServerCertificate=true;");
        }



    }
}
