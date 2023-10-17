using Domain.Entities;

namespace Domain.Interfaces;
public interface IVeterinarioRepository : IGenericRepository<Veterinario>
{
    //consultas avanzadas
    Task<IEnumerable<Veterinario>> GetbyEspecialidad(string _especialidad);
    Task<IEnumerable<object>> GetByVeterinario(string veterinario);
}