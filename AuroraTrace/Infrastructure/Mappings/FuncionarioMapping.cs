using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuroraTrace.Domain.Entity;

namespace AuroraTrace.Infrastructure.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionarios");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("nome");

            builder.Property(f => f.Matricula)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasColumnName("matricula");

            builder.Property(f => f.Cargo)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("cargo");

            builder.Property(f => f.Telefone)
                   .HasMaxLength(20)
                   .HasColumnName("telefone");
        }
    }
}
