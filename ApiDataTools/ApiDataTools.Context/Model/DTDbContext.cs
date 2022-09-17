using ApiDataTools.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiDataTools.Context.Model
{
    public sealed partial class DTDbContext : DbContext
    {
        public DTDbContext()
            : base()
        {
        }

        public DTDbContext(DbContextOptions<DTDbContext> options)
             : base(options)
        {
        }

        public DbSet<ConsultaEmpresaDetalle> ConsultaEmpresaDetalle { get; set; }
        public DbSet<ConsultaEmpresas> ConsultaEmpresas { get; set; }
        public DbSet<ConsultaTipoIdentificacion> ConsultaTipoIdentificacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultaEmpresaDetalle>().HasNoKey().ToView(null);
            modelBuilder.Entity<ConsultaEmpresas>().HasNoKey().ToView(null);
            modelBuilder.Entity<ConsultaTipoIdentificacion>().HasNoKey().ToView(null);
        }
    }
}
