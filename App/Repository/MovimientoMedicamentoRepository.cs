using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class MovimientoMedicamentoRepository : GenericRepository<MovimientoMedicamento>, IMovimientoMedicamentoRepository
{
    private readonly ApiContext _context;
    public MovimientoMedicamentoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoMedicamento>> GetAllAsync()
    {
        return await _context.MovimientosMedicamentos
            //.Include(c => c.User)
            //.Include(c => c.Propietario)
            //.Include(c => c.TipoMovimiento)
            .ToListAsync();
    }

    public override async Task<MovimientoMedicamento> GetByIdAsync(int id)
    {
        return await _context.MovimientosMedicamentos
            .Include(c => c.User)
            .Include(c => c.Propietario)
            .Include(c => c.TipoMovimiento)
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    //consultas especificas v1.1

    public async Task<IEnumerable<object>> GetWT()
    {
        var mas = await
        (
            from mm in _context.MovimientosMedicamentos
            join dm in _context.DetallesMovimientos on mm.Id equals dm.IdMovMedFk
            join p in _context.Propietarios on mm.IdPropietarioFk equals p.Id
            join tm in _context.TiposMovimientos on mm.IdTipMovFk equals tm.Id
            join u in _context.Users on mm.IdUserFk equals u.Id
            select new
            {
                IdMovimiento = mm.Id,
                Fecha = mm.Fecha,
                IdUser = mm.IdUserFk,
                NombreUser = u.Nombre,
                IdPropietario = p.Id,
                NombrePropietario = p.Nombre,
                IdTipoMovimiento = mm.IdTipMovFk,
                TipoMovimiento = tm.Descripcion
            }
        )
        .ToListAsync();
        return mas;
    }
}