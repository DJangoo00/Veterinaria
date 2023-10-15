using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using App.Repository;

namespace Aplicacion.Repository;

public class EspecieRepository : GenericRepository<Especie>, IEspecieRepository
{
    private readonly ApiContext _context;
    public EspecieRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Especie>> GetAllAsync()
    {
        return await _context.Especies
            .ToListAsync();
    }

    public override async Task<Especie> GetByIdAsync(int id)
    {
        return await _context.Especies
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}