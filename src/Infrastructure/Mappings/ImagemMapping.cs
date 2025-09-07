namespace Infrastructure.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entity;

    public class ImagemMapping : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.ToTable("AuroraImagens");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.CaminhoArquivo)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("caminho_arquivo");

            builder.Property(i => i.CapturadaEm)
                   .IsRequired()
                   .HasColumnName("capturada_em");

            builder.HasOne(i => i.Camera)
                   .WithMany()
                   .HasForeignKey(i => i.CameraId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Moto)
                   .WithMany()
                   .HasForeignKey(i => i.MotoId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.Metadata.FindNavigation(nameof(Imagem.Camera))!
                   .SetPropertyAccessMode(PropertyAccessMode.Property);

            builder.Metadata.FindNavigation(nameof(Imagem.Moto))!
                   .SetPropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
