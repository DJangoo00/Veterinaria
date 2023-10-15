using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using App.Repository;

namespace Aplicacion.Repository;

public class DetalleMovimientoRepository : GenericRepository<DetalleMovimiento>, IDetalleMovimientoRepository
{
    private readonly ApiContext _context;
    public DetalleMovimientoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleMovimiento>> GetAllAsync()
    {
        return await _context.DetallesMovimientos
            .ToListAsync();
    }

    public override async Task<DetalleMovimiento> GetByIdAsync(int id)
    {
        return await _context.DetallesMovimientos
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}