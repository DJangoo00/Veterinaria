using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
    {
        public void Configure(EntityTypeBuilder<Veterinario> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("veterinario");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasColumnType("Varchar")
            .HasMaxLength(50);

            builder.Property(p => p.CorreoElectronico)
            .IsRequired()
            .HasColumnType("Varchar")
            .HasMaxLength(100);

            builder.Property(p => p.Telefono)
            .IsRequired()
            .HasColumnType("Varchar")
            .HasMaxLength(20);

            builder.Property(p => p.Especialidad)
            .IsRequired()
            .HasColumnType("Varchar")
            .HasMaxLength(50);
        }
    }
}