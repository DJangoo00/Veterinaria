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
            .Include(c => c.Propietario)
            .Include(c => c.Especie)
            .Include(c => c.Raza)
            .ToListAsync();
    }

    public override async Task<Mascota> GetByIdAsync(int id)
    {
        return await _context.Mascotas
            .Include(c => c.Propietario)
            .Include(c => c.Especie)
            .Include(c => c.Raza)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    //consultas especificas v1.0

    public async Task<IEnumerable<Mascota>> GetByEspecie(string _especie)
    {
        var mas = await
        (
            from m in _context.Mascotas
            join e in _context.Especies on m.IdEspecieFk equals e.Id
            where e.Nombre.Contains(_especie)
            select m
        )
        .ToListAsync();
        return mas;
    }

    public async Task<IEnumerable<object>> GetGroupByEspecie()
    {
        var mas = await
        (
            from m in _context.Mascotas
            join e in _context.Especies on m.IdEspecieFk equals e.Id
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            group new { m, e, r, p } by e.Nombre into especgroup
            select new
            {
                Especie = especgroup.Key,
                Mascotas = especgroup.Select(x => new
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

    public async Task<IEnumerable<object>> GetByRaza(string raza)
    {
        var mas = await
        (
            from m in _context.Mascotas
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            where r.Nombre.Contains(raza)
            group new { m, r, p } by r.Nombre into especgroup
            select new
            {
                Raza = especgroup.Key,
                Mascotas = especgroup.Select(x => new
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

    public async Task<IEnumerable<object>> GetBy3MandMotivo(string motivo, int trimestre, int year)
    {
        var minMonth = 1;
        var maxMonth = 12;
        switch (trimestre)
        {
            case 1:
                minMonth = 1;
                maxMonth = 3;
                break;
            case 2:
                minMonth = 4;
                maxMonth = 6;
                break;
            case 3:
                minMonth = 7;
                maxMonth = 9;
                break;
            case 4:
                minMonth = 10;
                maxMonth = 12;
                break;
            default:
                break;
        }
        var mas = await
        (
            from m in _context.Mascotas
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join e in _context.Especies on m.IdEspecieFk equals e.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            join c in _context.Citas on m.Id equals c.IdMascotaFk
            where c.Motivo.Contains(motivo)
            where c.Fecha.Year == year
            where (c.Fecha.Month >= minMonth && c.Fecha.Month <= maxMonth)
            select new
            {
                NombreMascota = m.Nombre,
                IdMascota = m.Id,
                IdEspecie = m.IdEspecieFk,
                Especie = e.Nombre,
                IdRaza = m.IdRazaFk,
                NombreRaza = r.Nombre,
                IdPropietario = m.IdPropietarioFk,
                NombrePropietario = p.Nombre,
                TelefonoPropietario = p.Telefono,
                FechaCita = c.Fecha,
                HoraCita = c.Hora
            }
        )
        .ToListAsync();
        return mas;
    }

    public async Task<IEnumerable<object>> GetGroupbyRaza()
    {
        var mas = await
        (
            from m in _context.Mascotas
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            group new { m, r, p } by r.Nombre into especgroup
            select new
            {
                Raza = especgroup.Key,
                Conteo = especgroup.Count(),
                Mascotas = especgroup.Select(x => new
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

    //consultas especificas v1.1

    public async Task<(int totalRegistros, IEnumerable<object> registros)> GetByEspeciePg(int pageIndex, int pageSize, string Search)
    {
        var query =
        (
            from m in _context.Mascotas
            join e in _context.Especies on m.IdEspecieFk equals e.Id
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            select new
            {
                NombreMascota = m.Nombre,
                IdMascota = m.Id,
                IdEspecie = m.IdEspecieFk,
                Especie = e.Nombre,
                IdRaza = m.IdRazaFk,
                NombreRaza = r.Nombre,
                IdPropietario = m.IdPropietarioFk,
                NombrePropietario = p.Nombre,
                TelefonoPropietario = p.Telefono,
            }
        )/* .Distinct() */;
        if (!String.IsNullOrEmpty(Search))
        {
            query = query.Where(m => m.Especie.ToLower().Contains(Search));
        }
        query = query.OrderBy(m => m.IdMascota);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<(int totalRegistros, IEnumerable<object> registros)> GetBy3MandMotivoPg(int trimestre, int year, int pageIndex, int pageSize, string Search)
    {
        var minMonth = 1;
        var maxMonth = 12;
        switch (trimestre)
        {
            case 1:
                minMonth = 1;
                maxMonth = 3;
                break;
            case 2:
                minMonth = 4;
                maxMonth = 6;
                break;
            case 3:
                minMonth = 7;
                maxMonth = 9;
                break;
            case 4:
                minMonth = 10;
                maxMonth = 12;
                break;
            default:
                break;
        }
        var query =
        (
            from m in _context.Mascotas
            join e in _context.Especies on m.IdEspecieFk equals e.Id
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            join c in _context.Citas on m.Id equals c.IdMascotaFk
            where c.Fecha.Year == year
            where minMonth <= c.Fecha.Month && c.Fecha.Month <= maxMonth
            select new
            {
                NombreMascota = m.Nombre,
                IdMascota = m.Id,
                IdEspecie = m.IdEspecieFk,
                Especie = e.Nombre,
                IdRaza = m.IdRazaFk,
                NombreRaza = r.Nombre,
                IdPropietario = m.IdPropietarioFk,
                NombrePropietario = p.Nombre,
                TelefonoPropietario = p.Telefono,
                MotivoCita = c.Motivo
            }
        )/* .Distinct() */;
        if (!String.IsNullOrEmpty(Search))
        {
            query = query.Where(m => m.MotivoCita.ToLower().Contains(Search));
        }
        query = query.OrderBy(m => m.IdMascota);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<(int totalRegistros, IEnumerable<object> registros)> GetGroupByEspeciePg(int pageIndex, int pageSize, string search)
    {
        var query =
        (
            from m in _context.Mascotas
            join e in _context.Especies on m.IdEspecieFk equals e.Id
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            group new {m,e,r,p} by e.Nombre into g
            select new
            {
                Especie = g.Key,
                Mascotas = g.Select( x => new
                {
                    NombreMascota = x.m.Nombre,
                    IdMascota = x.m.Id,
                    IdRaza = x.m.IdRazaFk,
                    NombreRaza = x.r.Nombre,
                    IdPropietario = x.m.IdPropietarioFk,
                    NombrePropietario = x.p.Nombre,
                    TelefonoPropietario = x.p.Telefono
                }
                )/* .OrderBy(x => x.IdMascota) */
            }
        )/* .Distinct() */;
        query = query.OrderBy(m => m.Especie);
        if (!String.IsNullOrEmpty(search))
        {
            query = query.Where(m => m.Especie.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<(int totalRegistros, IEnumerable<object> registros)> GetByRazaPg(int pageIndex, int pageSize, string Search)
    {
        var query =
        (
            from m in _context.Mascotas
            join e in _context.Especies on m.IdEspecieFk equals e.Id
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            select new
            {
                NombreMascota = m.Nombre,
                IdMascota = m.Id,
                IdEspecie = m.IdEspecieFk,
                Especie = e.Nombre,
                IdRaza = m.IdRazaFk,
                NombreRaza = r.Nombre,
                IdPropietario = m.IdPropietarioFk,
                NombrePropietario = p.Nombre,
                TelefonoPropietario = p.Telefono,
            }
        )/* .Distinct() */;
        if (!String.IsNullOrEmpty(Search))
        {
            query = query.Where(m => m.NombreRaza.ToLower().Contains(Search));
        }
        query = query.OrderBy(m => m.IdMascota);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<(int totalRegistros, IEnumerable<object> registros)> GetGroupbyRazaPg(int pageIndex, int pageSize, string search)
    {
        var query =
        (
            from m in _context.Mascotas
            join e in _context.Especies on m.IdEspecieFk equals e.Id
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            group new {m,e,r,p} by e.Nombre into g
            select new
            {
                Especie = g.Key,
                Mascotas = g.Select( x => new
                {
                    NombreMascota = x.m.Nombre,
                    IdMascota = x.m.Id,
                    IdRaza = x.m.IdRazaFk,
                    NombreRaza = x.r.Nombre,
                    IdPropietario = x.m.IdPropietarioFk,
                    NombrePropietario = x.p.Nombre,
                    TelefonoPropietario = x.p.Telefono
                }
                )/* .OrderBy(x => x.IdMascota) */
            }
        )/* .Distinct() */;
        query = query.OrderBy(m => m.Especie);
        if (!String.IsNullOrEmpty(search))
        {
            query = query.Where(m => m.Especie.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
}