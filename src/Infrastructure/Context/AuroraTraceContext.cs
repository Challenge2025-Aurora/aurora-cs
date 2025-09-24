using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Infrastructure.Mappings;

namespace Infrastructure.Context
{
    public class AuroraTraceContext(DbContextOptions<AuroraTraceContext> options) : DbContext(options)
    {
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Patio> Patios { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Deteccao> Deteccoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotoMapping());
            modelBuilder.ApplyConfiguration(new PatioMapping());
            modelBuilder.ApplyConfiguration(new SetorMapping());
            modelBuilder.ApplyConfiguration(new EventoMapping());
            modelBuilder.ApplyConfiguration(new DeteccaoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
