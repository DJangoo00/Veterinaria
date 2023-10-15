using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class TratamientoMedicoRepository : GenericRepository<TratamientoMedico>, ITratamientoMedicoRepository
{
    private readonly ApiContext _context;
    public TratamientoMedicoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TratamientoMedico>> GetAllAsync()
    {
        return await _context.TratamientosMedicos
            .ToListAsync();
    }

    public override async Task<TratamientoMedico> GetByIdAsync(int id)
    {
        return await _context.TratamientosMedicos
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}