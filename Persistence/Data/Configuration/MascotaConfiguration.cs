using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("mascota");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasColumnType("Varchar")
            .HasMaxLength(20);

            builder.Property(p => p.FechaNacimiento)
            .IsRequired()
            .HasColumnType("date");

            builder.HasOne(p => p.Propietario)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.IdPropietarioFk);

            builder.HasOne(p => p.Especie)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.IdEspecieFk);

            builder.HasOne(p => p.Raza)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.IdRazaFk);
        }
    }
}