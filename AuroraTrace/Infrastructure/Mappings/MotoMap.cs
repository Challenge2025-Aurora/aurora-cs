namespace AuroraTrace.Infrastructure.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using AuroraTrace.Domain.Entity;

    public class MotoMap : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.ToTable("Motos");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Placa).IsRequired().HasMaxLength(10);
            builder.Property(m => m.Modelo).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Status).IsRequired();
            builder.Property(m => m.UltimaAtualizacao).IsRequired();

            builder.HasOne(m => m.Patio)
                   .WithMany()
                   .HasForeignKey(m => m.PatioId);

            builder.HasOne(m => m.Funcionario)
                   .WithMany()
                   .HasForeignKey(m => m.FuncionarioId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.Localizacao)
                   .WithMany()
                   .HasForeignKey(m => m.LocalizacaoId);
        }
    }

}
