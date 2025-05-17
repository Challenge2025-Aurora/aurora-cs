using Microsoft.EntityFrameworkCore;
using AuroraTrace.Domain.Entity;
using AuroraTrace.Infrastructure.Mappings;

namespace AuroraTrace.Infrastructure.Context
{
    public class AuroraTraceContext(DbContextOptions<AuroraTraceContext> options) : DbContext(options)
    {
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Patio> Patios { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotoMapping());
            modelBuilder.ApplyConfiguration(new ImagemMapping());
            modelBuilder.ApplyConfiguration(new CameraMapping());
            modelBuilder.ApplyConfiguration(new PatioMapping());
            modelBuilder.ApplyConfiguration(new LocalizacaoMapping());
            modelBuilder.ApplyConfiguration(new  FuncionarioMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
