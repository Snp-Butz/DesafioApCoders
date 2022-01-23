using Microsoft.EntityFrameworkCore;
using mvc_web_app.Models;

namespace mvc_web_app
{
    public class MvcWebAppContext : DbContext
    {
        public MvcWebAppContext(DbContextOptions<MvcWebAppContext> options) : base(options)
        {
            //
        }

        public DbSet<Inquilino> inquilinos { get; set; }

        public DbSet<Unidade> Unidades { get; set; }

        public DbSet<DespesaDaUnidade> DespesasDasUnidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}