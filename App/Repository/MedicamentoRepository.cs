using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamentoRepository
{
    private readonly ApiContext _context;
    public MedicamentoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos
            .Include(c => c.Laboratorio)
            .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Medicamentos
            .Include(c => c.Laboratorio)
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    //consultas especificas v1.0
    //consulta 2
    public async Task<IEnumerable<Medicamento>> GetbyLabName(string _labName)
    {
        var meds = await 
        (
            from m in _context.Medicamentos
            join l in _context.Laboratorios on m.IdLaboratorioFk equals l.Id
            where l.Nombre.Contains(_labName)
            select m
        ).ToListAsync();
        return meds;
    }
    //consulta 5
    public async Task<IEnumerable<Medicamento>> GetUpperPrice(int price)
    {
        var meds = await 
        (
            from m in _context.Medicamentos
            where (m.Precio >= price)
            select m
        )
        .Include(m => m.Laboratorio)
        .ToListAsync();
        return meds;
    }

    //consultas especificas v1.1
    //consulta 2pg

    public async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetbyLabNamePg(int pageIndex, int pageSize, string search)
    {
        var query = (
            from m in _context.Medicamentos
            join l in _context.Laboratorios on m.IdLaboratorioFk equals l.Id
            where l.Nombre.ToLower().Contains(search)
            select m 
        );
        /* if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(l => l.Nombre.ToLower().Contains(search));
        } */
        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    
}