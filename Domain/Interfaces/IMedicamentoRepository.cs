using Domain.Entities;

namespace Domain.Interfaces;
public interface IMedicamentoRepository : IGenericRepository<Medicamento>
{
    //consultas avanzadas
    Task<IEnumerable<Medicamento>> GetbyLabName(string _labName);
    Task<IEnumerable<Medicamento>> GetUpperPrice(int price);
    Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetbyLabNamePg(int pageIndex, int pageSize, string _search);
    Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetUpperPricePg(int pageIndex, int pageSize, string search);
}