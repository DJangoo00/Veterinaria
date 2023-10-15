using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class MovimientoMedicamentoRepository : GenericRepository<MovimientoMedicamento>, IMovimientoMedicamentoRepository
{
    private readonly ApiContext _context;
    public MovimientoMedicamentoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoMedicamento>> GetAllAsync()
    {
        return await _context.MovimientosMedicamentos
            .ToListAsync();
    }

    public override async Task<MovimientoMedicamento> GetByIdAsync(int id)
    {
        return await _context.MovimientosMedicamentos
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}