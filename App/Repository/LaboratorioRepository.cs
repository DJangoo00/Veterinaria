using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using App.Repository;

namespace Aplicacion.Repository;

public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorioRepository
{
    private readonly ApiContext _context;
    public LaboratorioRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Laboratorio>> GetAllAsync()
    {
        return await _context.Laboratorios
            .ToListAsync();
    }

    public override async Task<Laboratorio> GetByIdAsync(int id)
    {
        return await _context.Laboratorios
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}