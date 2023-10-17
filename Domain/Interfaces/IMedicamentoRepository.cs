using Domain.Entities;

namespace Domain.Interfaces;
public interface IMedicamentoRepository : IGenericRepository<Medicamento>
{
    //consultas avanzadas
    Task<IEnumerable<Medicamento>> GetbyLabName(string _labName);
    Task<IEnumerable<Medicamento>> GetUpperPrice(int price);
}