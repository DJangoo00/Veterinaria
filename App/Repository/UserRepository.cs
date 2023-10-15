using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApiContext _context;
    public UserRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .ToListAsync();
    }

    public override async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}