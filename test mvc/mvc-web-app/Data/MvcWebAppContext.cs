using Microsoft.EntityFrameworkCore;
using mvc_web_app.Models;

namespace mvc_web_app
{
    public class MvcWebAppContext : DbContext
    {
        public MvcWebAppContext(DbContextOptions<MvcWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Inquilino> inquilino { get; set; }

        public DbSet<Unidade> Unidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Inquilino>().HasMany(p => p.unidades).WithOne();
            //modelBuilder.Entity<Unidade>().HasOne(p => p.inquilino).WithMany();

            //modelBuilder.Entity<Inquilino>().Navigation(b => b.unidades).UsePropertyAccessMode(PropertyAccessMode.Property);
            //modelBuilder.Entity<Unidade>().Navigation(b=>b.inquilino).UsePropertyAccessMode(PropertyAccessMode.pro)

            //modelBuilder.Entity<Unidade>().HasOne(p => p.inquilino).WithMany(b => b.unidades).HasForeignKey(p => p.proprietario);

        }
    }
}