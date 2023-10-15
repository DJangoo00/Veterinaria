using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        {
            builder.ToTable("user");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(p => p.Nombre)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(p => p.Correo)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(p => p.Password)
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

            builder
            .HasMany(p => p.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<RoleUser>(

            j => j
                .HasOne(pt => pt.Role)
                .WithMany(t => t.RolesUsers)
                .HasForeignKey(ut => ut.IdRoleFk),
            j => j
                .HasOne(et => et.User)
                .WithMany(et => et.RolesUsers)
                .HasForeignKey(el => el.IdUserFk),
            j =>
                {
                    j.ToTable("userrole");
                    j.HasKey(t => new { t.IdRoleFk, t.IdUserFk });
                });

            builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.IdUserFk);
        }

    }
}