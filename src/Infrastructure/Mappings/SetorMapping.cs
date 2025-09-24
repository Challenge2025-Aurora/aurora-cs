using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entity;

namespace Infrastructure.Mappings
{
    public class SetorMapping : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.ToTable("AuroraSetores");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("nome");

            builder.Property(s => s.Slots)
                   .IsRequired()
                   .HasColumnName("slots");

            builder.Property(s => s.PatioId)
                   .IsRequired()
                   .HasColumnName("patio_id");

            builder.HasOne(s => s.Patio)
                   .WithMany(p => p.Setores)
                   .HasForeignKey(s => s.PatioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Metadata.FindNavigation(nameof(Setor.Patio))!
                   .SetPropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
