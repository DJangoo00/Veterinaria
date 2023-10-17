using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
{
    private readonly ApiContext _context;
    public ProveedorRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedores
            .ToListAsync();
    }

    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Proveedores
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    //consultas especificas v1.1
    public async Task<IEnumerable<object>> GetbyMedName(string medicamento)
    {
        var mas = await 
        (
            from p in _context.Proveedores
            join mp in _context.MedicamentosProveedores on p.Id equals mp.IdProveedor
            join m in _context.Medicamentos on mp.IdMedicamento equals m.Id
            where m.Nombre.Contains(medicamento)
            group new {p, m} by p.Nombre into especgroup
            select new 
            {
                Proveedor = especgroup.Key,
                Medicamentos = especgroup.Select(x => new
                {
                    NombreMedicamento = x.m.Nombre,
                    IdMedicamento = x.m.Id
                })
            }
        )
        .ToListAsync();
        return mas;
    }
}