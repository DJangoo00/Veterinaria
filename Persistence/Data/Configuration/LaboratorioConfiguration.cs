using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
    {
        public void Configure(EntityTypeBuilder<Laboratorio> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("laboratorio");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(p => p.Direccion)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(100);

            builder.Property(p => p.Telefono)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(20);
        }
    }
}