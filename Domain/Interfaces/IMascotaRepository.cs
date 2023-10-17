using Domain.Entities;

namespace Domain.Interfaces;

public interface IMascotaRepository : IGenericRepository<Mascota>
{
    Task<IEnumerable<Mascota>> GetByEspecie(string _especie);
    Task<IEnumerable<object>> GetGroupByEspecie();
    Task<IEnumerable<object>> GetBy3MandMotivo(string motivo, int trimestre, int year);
    Task<IEnumerable<object>> GetByRaza(string raza);
    Task<IEnumerable<object>> GetGroupbyRaza();
}
