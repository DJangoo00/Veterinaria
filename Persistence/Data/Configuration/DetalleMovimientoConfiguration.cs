using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
    {
        public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("detalleMovimiento");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Cantidad)
            .IsRequired()
            .HasColumnType("int")
            .HasMaxLength(5);

            builder.Property(p => p.Precio)
            .IsRequired()
            .HasColumnType("int")
            .HasMaxLength(7);

            builder.HasOne(p => p.Medicamento)
            .WithMany(p => p.DetallesMovimientos)
            .HasForeignKey(p => p.IdMedicamentoFk);

            builder.HasOne(p => p.MovimientoMedicamento)
            .WithMany(p => p.DetallesMovimientos)
            .HasForeignKey(p => p.IdMovMedFk);

            
        }
    }
}