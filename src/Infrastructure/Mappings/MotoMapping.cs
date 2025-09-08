namespace Infrastructure.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entity;

    public class MotoMapping : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.ToTable("AuroraMotos");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Placa)
                   .IsRequired()
                   .HasMaxLength(10)
                   .HasColumnName("placa");

            builder.Property(m => m.Modelo)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("modelo");

            builder.Property(m => m.Status)
                   .IsRequired()
                   .HasColumnName("status");

            builder.Property(m => m.UltimaAtualizacao)
                   .IsRequired()
                   .HasColumnName("ultima_atualizacao");

            builder.HasOne(m => m.Patio)
                   .WithMany()
                   .HasForeignKey(m => m.PatioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Funcionario)
                   .WithMany()
                   .HasForeignKey(m => m.FuncionarioId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.OwnsOne(m => m.Localizacao, localizacao =>
            {
                localizacao.Property(l => l.Latitude)
                           .IsRequired()
                           .HasColumnName("latitude");

                localizacao.Property(l => l.Longitude)
                           .IsRequired()
                           .HasColumnName("longitude");
            });

            builder.Metadata.FindNavigation(nameof(Moto.Patio))!
                   .SetPropertyAccessMode(PropertyAccessMode.Property);

            builder.Metadata.FindNavigation(nameof(Moto.Funcionario))!
                   .SetPropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
