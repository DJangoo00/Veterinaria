//dependencias externas
using Microsoft.EntityFrameworkCore;
using System.Reflection;
//namespaces internos
using Domain.Entities;

namespace Persistence;
public class ApiContext : DbContext //Clase de abstraccion para facilitar interaccion
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    
    //DbSet uno para cada entidad a implementar
    public DbSet<Cita> Citas { get; set; }
    public DbSet<DetalleMovimiento> DetallesMovimientos { get; set; }
    public DbSet<Especie> Especies { get; set; }
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<MedicamentoProveedor> MedicamentosProveedores { get; set; }
    public DbSet<MovimientoMedicamento> MovimientosMedicamentos { get; set; }
    public DbSet<Propietario> Propietarios { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Raza> Razas { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleUser> RolesUsers { get; set; }
    public DbSet<TipoMovimiento> TiposMovimientos { get; set; }
    public DbSet<TratamientoMedico> TratamientosMedicos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Veterinario> Veterinarios { get; set; }
        
    //metodo para aplicar las configuracion de las entidades
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
