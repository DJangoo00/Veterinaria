using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class CitaConfiguration : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("cita");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Fecha)
            .IsRequired()
            .HasColumnType("date");

            builder.Property(p => p.Hora)
            .IsRequired()
            .HasColumnType("time");

            builder.Property(p => p.Motivo)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(250);

            builder.HasOne(p => p.Mascota)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.IdMascotaFk);

            builder.HasOne(p => p.Veterinario)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.IdVeterinarioFk);
        }
    }
}