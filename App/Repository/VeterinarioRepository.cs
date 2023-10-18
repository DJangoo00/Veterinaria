using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinarioRepository
{
    private readonly ApiContext _context;
    public VeterinarioRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    //Consultas Genericas, desarrolladas en api v1.0
    public override async Task<IEnumerable<Veterinario>> GetAllAsync()
    {
        return await _context.Veterinarios
            .ToListAsync();
    }

    public override async Task<Veterinario> GetByIdAsync(int id)
    {
        return await _context.Veterinarios
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    //Consultas especificas v1.0
    public async Task<IEnumerable<Veterinario>> GetbyEspecialidad(string _especialidad)
    {
        var vets = await
        (
            from v in _context.Veterinarios
            where v.Especialidad.Contains(_especialidad)
            select v
        ).ToListAsync();
        return vets;
    }
    public async Task<IEnumerable<object>> GetByVeterinario(string veterinario)
    {
        var mas = await
        (
            from v in _context.Veterinarios
            where v.Nombre.ToLower().Contains(veterinario)
            join c in _context.Citas on v.Id equals c.IdVeterinarioFk
            join m in _context.Mascotas on c.IdMascotaFk equals m.Id
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            group new { v, c, m, r, p } by v.Nombre into especgroup
            select new
            {
                Veterinario = especgroup.Key,
                Mascostas = especgroup.Select(x => new
                {
                    NombreMascota = x.m.Nombre,
                    IdMascota = x.m.Id,
                    IdRaza = x.m.IdRazaFk,
                    NombreRaza = x.r.Nombre,
                    IdPropietario = x.m.IdPropietarioFk,
                    NombrePropietario = x.p.Nombre,
                    TelefonoPropietario = x.p.Telefono
                })
            }
        )
        .ToListAsync();
        return mas;
    }

    //Consultas especificas v1.1
    //consulta 1 con pg
    public async Task<(int totalRegistros, IEnumerable<Veterinario> registros)> GetByEspecialidadPg(int pageIndex, int pageSize, string Search)
    {
        var query = _context.Veterinarios as IQueryable<Veterinario>;
        if (!string.IsNullOrEmpty(Search))
        {
            query = query.Where(v => v.Especialidad.ToLower().Contains(Search));
        }
        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    //consulta 9 con pg
    public async Task<(int totalRegistros, IEnumerable<object> registros)> GetPetByVet(int pageIndex, int pageSize, string Search)
    {
        var query = 
        (
            from v in _context.Veterinarios
            join c in _context.Citas on v.Id equals c.IdVeterinarioFk
            join m in _context.Mascotas on c.IdMascotaFk equals m.Id
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            group new { v, c, m, r, p } by v.Nombre into especgroup
            select new
            {
                Veterinario = especgroup.Key,
                Mascostas = especgroup.Select(x => new
                {
                    NombreMascota = x.m.Nombre,
                    IdMascota = x.m.Id,
                    IdRaza = x.m.IdRazaFk,
                    NombreRaza = x.r.Nombre,
                    IdPropietario = x.m.IdPropietarioFk,
                    NombrePropietario = x.p.Nombre,
                    TelefonoPropietario = x.p.Telefono
                })/*. OrderBy(p => p.IdMascota) */
            }
        )/* .Distinct() */;
        if(!String.IsNullOrEmpty(Search))
        {
            query = query.Where(p => p.Veterinario.ToLower().Contains(Search));
        }
        query = query.OrderBy(p => p.Veterinario);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
}