using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entity;

namespace Infrastructure.Mappings
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("AuroraEventos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Tipo)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("tipo");

            builder.Property(e => e.Descricao)
                   .HasMaxLength(500)
                   .HasColumnName("descricao");

            builder.Property(e => e.CriadoEm)
                   .IsRequired()
                   .HasColumnName("criado_em");

            builder.Property(e => e.MotoId)
                   .IsRequired()
                   .HasColumnName("moto_id");

            builder.HasOne(e => e.Moto)
                   .WithMany()
                   .HasForeignKey(e => e.MotoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata.FindNavigation(nameof(Evento.Moto))!
                   .SetPropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
