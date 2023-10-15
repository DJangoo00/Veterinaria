using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("medicamento");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasColumnType("Varchar")
            .HasMaxLength(50);

            builder.Property(p => p.CantidadDisponible)
            .IsRequired()
            .HasColumnType("int")
            .HasMaxLength(5);

            builder.Property(p => p.Precio)
            .IsRequired()
            .HasColumnType("int")
            .HasMaxLength(7);

            builder.HasOne(p => p.Laboratorio)
            .WithMany(p => p.Medicamentos)
            .HasForeignKey(p => p.IdLaboratorioFk);

            builder
            .HasMany(p => p.Proveedores)
            .WithMany(m => m.Medicamentos)
            .UsingEntity<MedicamentoProveedor>(
                j => j
                    .HasOne(pt => pt.Proveedor)
                    .WithMany(t => t.MedicamentosProveedores)
                    .HasForeignKey(pt => pt.IdProveedor),
                j => j
                    .HasOne(pt => pt.Medicamento)
                    .WithMany(t => t.MedicamentosProveedores)
                    .HasForeignKey(pt => pt.IdMedicamento),
                j => 
                    {
                        j.ToTable("medicamentoProveedor");
                        j.HasKey(t => new {t.IdProveedor, t.IdMedicamento});
                    });
        }
    }
}