using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
    {
        public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("tratamientoMedico");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Dosis)
            .IsRequired()
            .HasColumnType("Varchar")
            .HasMaxLength(50);

            builder.Property(p => p.Observacion)
            .IsRequired()
            .HasColumnType("Varchar")
            .HasMaxLength(50);

            builder.Property(p => p.FechaAdministracion)
            .IsRequired()
            .HasColumnType("date");

            builder.HasOne(p => p.Cita)
            .WithMany(p => p.TratamientosMedicos)
            .HasForeignKey(p => p.IdCitaFk);

            builder.HasOne(p => p.Medicamento)
            .WithMany(p => p.TratamientosMedicos)
            .HasForeignKey(p => p.IdMedicamentoFk);
        }
    }
}