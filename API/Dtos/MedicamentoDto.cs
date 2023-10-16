using Domain.Entities;
namespace API.Dtos;
public class MedicamentoDto : BaseEntity
{
    public string Nombre { get; set; }
    public int CantidadDisponible { get; set; }
    public int Precio { get; set; }
    public int IdLaboratorioFk { get; set; }
    public LaboratorioDto Laboratorio { get; set; }
}
