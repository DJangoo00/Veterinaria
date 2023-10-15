using Domain.Entities;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    ICitaRepository Citas { get; }
    IDetalleMovimientoRepository DetallesMovimientos { get; }
    IEspecieRepository Especies { get; }
    ILaboratorioRepository Laboratorios { get; }
    IMascotaRepository Mascotas { get; }
    IMedicamentoRepository Medicamentos { get; }
    IMovimientoMedicamentoRepository MovimientosMedicamentos { get; }
    IPropietarioRepository Propietarios { get; }
    IProveedorRepository Proveedores { get; }
    IRazaRepository Razas { get; }
    ITipoMovimientoRepository TiposMovimientos { get; }
    ITratamientoMedicoRepository TratamientosMedicos { get; }
    IVeterinarioRepository Veterinarios { get; }
    
    //JWT
    IUserRepository Users { get; }

    Task<int> SaveAsync();
}
