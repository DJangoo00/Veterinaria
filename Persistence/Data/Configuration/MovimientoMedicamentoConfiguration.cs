using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
    {
        public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("movimientoMedicamento");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Fecha)
            .IsRequired()
            .HasColumnType("date");

            builder.Property(p => p.Total)
            .IsRequired()
            .HasColumnType("int")
            .HasMaxLength(7);

            builder.HasOne(p => p.User)
            .WithMany(p => p.MovimientosMedicamentos)
            .HasForeignKey(p => p.IdUserFk);

            builder.HasOne(p => p.Propietario)
            .WithMany(p => p.MovimientosMedicamentos)
            .HasForeignKey(p => p.IdPropietarioFk);

            builder.HasOne(p => p.TipoMovimiento)
            .WithMany(p => p.MovimientosMedicamentos)
            .HasForeignKey(p => p.IdTipMovFk);
        }
    }
}