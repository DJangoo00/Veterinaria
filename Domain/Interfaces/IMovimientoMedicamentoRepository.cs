using Domain.Entities;

namespace Domain.Interfaces;
public interface IMovimientoMedicamentoRepository : IGenericRepository<MovimientoMedicamento>
{
    //consultas especificas v1.0
    Task<IEnumerable<object>> GetWT();
    //consultas especificas v1.1
    Task<(int totalRegistros, IEnumerable<object> registros)> GetWTPg(int pageIndex, int pageSize, string Search);
}