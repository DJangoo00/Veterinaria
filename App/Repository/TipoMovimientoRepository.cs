using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class TipoMovimientoRepository : GenericRepository<TipoMovimiento>, ITipoMovimientoRepository
{
    private readonly ApiContext _context;
    public TipoMovimientoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoMovimiento>> GetAllAsync()
    {
        return await _context.TiposMovimientos
            .ToListAsync();
    }

    public override async Task<TipoMovimiento> GetByIdAsync(int id)
    {
        return await _context.TiposMovimientos
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}