using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamentoRepository
{
    private readonly ApiContext _context;
    public MedicamentoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos
            .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Medicamentos
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}