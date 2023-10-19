using Domain.Entities;

namespace Domain.Interfaces;

public interface IPropietarioRepository : IGenericRepository<Propietario>
{
    Task<IEnumerable<object>> GetWM();
    Task<(int totalRegistros, IEnumerable<object> registros)> GetWMPg(int pageIndex, int pageSize, string Search);
}