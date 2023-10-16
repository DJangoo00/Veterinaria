using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Repository;

public class CitaRepository : GenericRepository<Cita>, ICitaRepository
{
    private readonly ApiContext _context;
    public CitaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _context.Citas
            .Include(c => c.Mascota)
            .Include(c => c.Veterinario)
            .ToListAsync();
    }

    public override async Task<Cita> GetByIdAsync(int id)
    {
        return await _context.Citas
            .Include(c => c.Mascota)
            .Include(c => c.Veterinario)
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}