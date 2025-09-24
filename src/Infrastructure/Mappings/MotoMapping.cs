using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entity;

namespace Infrastructure.Mappings
{
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
                   .HasConversion<string>()
                   .HasColumnName("status");

            builder.Property(m => m.AtualizadoEm)
                   .IsRequired()
                   .HasColumnName("atualizado_em");

            builder.Property(m => m.UltimoSetor)
                   .HasMaxLength(10)
                   .HasColumnName("ultimo_setor");

            builder.Property(m => m.UltimoSlot)
                   .HasMaxLength(10)
                   .HasColumnName("ultimo_slot");
        }
    }
}
