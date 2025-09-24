using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entity;

namespace Infrastructure.Mappings
{
    public class DeteccaoMapping : IEntityTypeConfiguration<Deteccao>
    {
        public void Configure(EntityTypeBuilder<Deteccao> builder)
        {
            builder.ToTable("AuroraDeteccoes");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Placa)
                   .HasMaxLength(10)
                   .HasColumnName("placa");

            builder.Property(d => d.ModeloProb)
                   .HasMaxLength(100)
                   .HasColumnName("modelo_prob");

            builder.Property(d => d.Confianca)
                   .IsRequired()
                   .HasColumnName("confianca");

            builder.Property(d => d.BboxX).HasColumnName("bbox_x");
            builder.Property(d => d.BboxY).HasColumnName("bbox_y");
            builder.Property(d => d.BboxW).HasColumnName("bbox_w");
            builder.Property(d => d.BboxH).HasColumnName("bbox_h");

            builder.Property(d => d.SetorEstimado)
                   .HasMaxLength(10)
                   .HasColumnName("setor_estimado");

            builder.Property(d => d.SlotEstimado)
                   .HasMaxLength(10)
                   .HasColumnName("slot_estimado");

            builder.Property(d => d.Timestamp)
                   .IsRequired()
                   .HasColumnName("timestamp");
        }
    }
}
