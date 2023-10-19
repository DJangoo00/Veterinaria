using Domain.Entities;

namespace Domain.Interfaces;
public interface IProveedorRepository : IGenericRepository<Proveedor>
{
    Task<IEnumerable<object>> GetbyMedName(string name);
    Task<(int totalRegistros, IEnumerable<object> registros)> GetbyMedNamePg(int pageIndex, int pageSize, string Search);
}