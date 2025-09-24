using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entity;

namespace Infrastructure.Mappings
{
    public class PatioMapping : IEntityTypeConfiguration<Patio>
    {
        public void Configure(EntityTypeBuilder<Patio> builder)
        {
            builder.ToTable("AuroraPatios");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("nome");

            builder.Property(p => p.Cols)
                   .IsRequired()
                   .HasColumnName("cols");

            builder.Property(p => p.Rows)
                   .IsRequired()
                   .HasColumnName("rows");

            builder.HasMany(p => p.Setores)
                   .WithOne(s => s.Patio)
                   .HasForeignKey(s => s.PatioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata.FindNavigation(nameof(Patio.Setores))!
                   .SetPropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
