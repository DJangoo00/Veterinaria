using Domain.Entities;

namespace Domain.Interfaces;
public interface IVeterinarioRepository : IGenericRepository<Veterinario>
{
    //consultas avanzadas
    Task<IEnumerable<Veterinario>> GetbyEspecialidad(string _especialidad);
    Task<IEnumerable<object>> GetByVeterinario(string veterinario);
    Task<(int totalRegistros, IEnumerable<Veterinario> registros)> GetByEspecialidadPg(int pageIndex, int pageSize, string _especialidad);
    Task<(int totalRegistros, IEnumerable<object> registros)> GetPetByVet(int pageIndex, int pageSize, string _search);
}