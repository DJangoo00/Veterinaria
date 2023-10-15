using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class MascotaRepository : GenericRepository<Mascota>, IMascotaRepository
{
    private readonly ApiContext _context;
    public MascotaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Mascota>> GetAllAsync()
    {
        return await _context.Mascotas
            .ToListAsync();
    }

    public override async Task<Mascota> GetByIdAsync(int id)
    {
        return await _context.Mascotas
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}