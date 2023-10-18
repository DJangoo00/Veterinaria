using Domain.Entities;

namespace Domain.Interfaces;

public interface IMascotaRepository : IGenericRepository<Mascota>
{
    Task<IEnumerable<Mascota>> GetByEspecie(string _especie);
    Task<IEnumerable<object>> GetGroupByEspecie();
    Task<IEnumerable<object>> GetBy3MandMotivo(string motivo, int trimestre, int year);
    Task<IEnumerable<object>> GetByRaza(string raza);
    Task<IEnumerable<object>> GetGroupbyRaza();
    Task<(int totalRegistros, IEnumerable<object> registros)> GetByEspeciePg(int pageIndex, int pageSize, string Search);
    Task<(int totalRegistros, IEnumerable<object> registros)> GetBy3MandMotivoPg(int trimestre, int year, int pageIndex, int pageSize, string Search);
    Task<(int totalRegistros, IEnumerable<object> registros)> GetGroupByEspeciePg(int pageIndex, int pageSize, string search);
    Task<(int totalRegistros, IEnumerable<object> registros)> GetByRazaPg(int pageIndex, int pageSize, string search);
    Task<(int totalRegistros, IEnumerable<object> registros)> GetGroupbyRazaPg(int pageIndex, int pageSize, string search);

}
