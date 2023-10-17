using Domain.Entities;

namespace Domain.Interfaces;
public interface IMovimientoMedicamentoRepository : IGenericRepository<MovimientoMedicamento>
{
    //consultas especificas v1.1
    Task<IEnumerable<object>> GetWT();
}