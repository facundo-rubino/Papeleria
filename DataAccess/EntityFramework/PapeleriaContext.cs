using Microsoft.EntityFrameworkCore;
using BussinessLogic.Entidades;
using BusinessLogic.Entidades;

namespace DataAccess.EntityFramework
{
    public class PapeleriaContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoComun> PedidosComunes { get; set; }
        public DbSet<PedidoExpress> PedidosExpress { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<TipoMovimiento> TiposMovimiento { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection string for Mac, Docker + Azure Data Studio
            optionsBuilder.UseSqlServer(
                @"Server=localhost,
                1433;
                Database=Papeleria_db;
                User=sa;
                Password=Desarrollo2024.;
                TrustServerCertificate=true;"
            );

            //Connection string for Windows, SQL Server Management Studio
            //optionsBuilder.UseSqlServer(
            //   @"SERVER=(localdb)\MsSqlLocalDb;
            //   DATABASE=Papeleria_db;
            //   Integrated Security=true;"
            //);


        }



    }
}
