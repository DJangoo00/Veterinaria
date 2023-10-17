using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class PropietarioRepository : GenericRepository<Propietario>, IPropietarioRepository
{
    private readonly ApiContext _context;
    public PropietarioRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Propietario>> GetAllAsync()
    {
        return await _context.Propietarios
            .ToListAsync();
    }

    public override async Task<Propietario> GetByIdAsync(int id)
    {
        return await _context.Propietarios
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    

    //consultas especificas v1.1
    public async Task<IEnumerable<object>> GetWM()
    {
        var prop = await 
        (
            from m in _context.Mascotas
            join e in _context.Especies on m.IdEspecieFk equals e.Id
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            group new {m, e, r, p} by p into especgroup
            select new 
            {
                IdPropietario = especgroup.Key.Id,
                NombrePropietario = especgroup.Key.Nombre,
                Mascotas = especgroup.Select(x => new
                {
                    NombreMascota = x.m.Nombre,
                    IdMascota = x.m.Id,
                    IdEspecie = x.m.IdEspecieFk,
                    NombreEspecie = x.e.Nombre,
                    IdRaza = x.m.IdRazaFk,
                    NombreRaza = x.r.Nombre,
                })
            }
        )
        .ToListAsync();
        return prop;
    }
}