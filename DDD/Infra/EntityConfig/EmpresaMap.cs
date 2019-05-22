using App.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfig
{
    public class EmpresaMap: IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(em => em.IdEmpresa);

            builder.HasMany(em => em.Enderecos)
                .WithOne(ende => ende.Empresa)
                .HasForeignKey(ende => ende.IdEmpresa);

            builder.Property(em => em.CNPJ)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(em => em.Nome)
                .HasColumnType("Varchar(255)")
                .IsRequired();

            builder.Property(em => em.Porte)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
