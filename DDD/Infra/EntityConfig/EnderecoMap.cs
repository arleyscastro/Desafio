using App.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfig
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(ende => ende.IdEmpresa);

            builder.HasOne(ende => ende.Empresa)
                .WithMany(emp => emp.Enderecos)
                .HasForeignKey(ende => ende.IdEmpresa);

            builder.Property(ende => ende.Logradouro)
                .HasColumnType("VarChar(200)")
                .IsRequired();

            builder.Property(ende => ende.CEP)
                .HasColumnType("VarChar(12)")
                .IsRequired();
        }
    }
}
