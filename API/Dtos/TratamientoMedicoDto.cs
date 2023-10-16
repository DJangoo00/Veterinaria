using Domain.Entities;
namespace API.Dtos;
public class TratamientoMedicoDto : BaseEntity
{
    public int IdCitaFk { get; set; }
    public CitaDto Cita { get; set; }
    public int IdMedicamentoFk { get; set; }
    public MedicamentoDto Medicamento { get; set; }
    public string Dosis { get; set; }
    public DateOnly FechaAdministracion { get; set; }
    public string Observacion { get; set; }
}