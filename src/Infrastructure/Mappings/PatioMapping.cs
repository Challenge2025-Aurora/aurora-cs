namespace Infrastructure.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entity;

    public class PatioMapping : IEntityTypeConfiguration<Patio>
    {
        public void Configure(EntityTypeBuilder<Patio> builder)
        {
            builder.ToTable("Patios");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("nome");

            builder.Property(p => p.Endereco)
                   .IsRequired()
                   .HasMaxLength(200)
                   .HasColumnName("endereco");

            builder.Property(p => p.Cidade)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("cidade");

            builder.Property(p => p.TamanhoMetros)
                   .IsRequired()
                   .HasColumnName("tamanho_metros");
        }
    }
}
