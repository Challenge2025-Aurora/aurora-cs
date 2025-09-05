namespace Infrastructure.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entity;

    public class CameraMapping : IEntityTypeConfiguration<Camera>
    {
        public void Configure(EntityTypeBuilder<Camera> builder)
        {
            builder.ToTable("Cameras");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("nome");

            builder.Property(c => c.Posicao)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("posicao");

            builder.Property(c => c.InstaladaEm)
                   .IsRequired()
                   .HasColumnName("instalada_em");

            builder.HasOne(c => c.Patio)
                   .WithMany()
                   .HasForeignKey(c => c.PatioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Metadata.FindNavigation(nameof(Camera.Patio))!
                   .SetPropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
